// Jeu de Tetris
// Programmé par Samuel Cloutier & Albert Ouellet
// Le jeu consiste à placer les blocs de façons à créer des lignes qui vont disparaitre
// pour gagner des points. Le but du jeu est de faire le plus de point possible.
// La partie se termine lorsque le joueur n'est plus capable de placer les blocs
// au point que le bloc va se geler dans le "spawn" du bloc.
//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TP3
{
  public partial class FormPrincipal : Form
  {
    public FormPrincipal()
    {
      FormStatistique stats = new FormStatistique(this);
      FormConfiguration config = new FormConfiguration(this);
      InitializeComponent();
    }

    #region Variable Partagées

    int[] blocActifY = new int[4];
    int[] blocActifX = new int[4];
    int[] nouveauBlocActifY = new int[4];
    int[] nouveauBlocActifX = new int[4];
    int ligneCourante = 0;
    int colonneCourante = 0;
    Deplacement mouvement = 0;
    // Représentation visuelles du jeu en mémoire.
    PictureBox[,] toutesImagesVisuelles = null;
    public int nbLignes = 20;
    public int nbColonnes = 10;
    TypeEtat[,] tableauEtats = new TypeEtat[20, 10];
    TypeEtat pieceTableau;
    bool partieEnCours = false;
    bool deplacementPossible = false;
    public int nbDeSeconde = 0;

    #endregion

    #region frmLoad
    /// <summary>
    /// Gestionnaire de l'événement se produisant lors du premier affichage 
    /// du formulaire principal.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmLoad(object sender, EventArgs e)
    {
      // Ne pas oublier de mettre en place les valeurs nécessaires à une partie.
      ExecuterTestsUnitaires();
      InitialiserSurfaceDeJeu(nbLignes, nbColonnes);
    }
    #endregion

    #region InitialiserSurFaceDeJeu
    public void InitialiserSurfaceDeJeu(int nbLignes, int nbCols)
    {
      // Création d'une surface de jeu 10 colonnes x 20 lignes
      toutesImagesVisuelles = new PictureBox[nbLignes, nbCols];
      tableauJeu.Controls.Clear();
      tableauJeu.ColumnCount = toutesImagesVisuelles.GetLength(1);
      tableauJeu.RowCount = toutesImagesVisuelles.GetLength(0);
      for (int i = 0; i < tableauJeu.RowCount; i++)
      {
        tableauJeu.RowStyles[i].Height = tableauJeu.Height / tableauJeu.RowCount;
        for (int j = 0; j < tableauJeu.ColumnCount; j++)
        {
          tableauJeu.ColumnStyles[j].Width = tableauJeu.Width / tableauJeu.ColumnCount;
          // Création dynamique des PictureBox qui contiendront les pièces de jeu
          PictureBox newPictureBox = new PictureBox();
          newPictureBox.Width = tableauJeu.Width / tableauJeu.ColumnCount;
          newPictureBox.Height = tableauJeu.Height / tableauJeu.RowCount;
          newPictureBox.BackColor = Color.Black;
          newPictureBox.Margin = new Padding(0, 0, 0, 0);
          newPictureBox.BorderStyle = BorderStyle.FixedSingle;
          newPictureBox.Dock = DockStyle.Fill;

          // Assignation de la représentation visuelle.
          toutesImagesVisuelles[i, j] = newPictureBox;
          // Ajout dynamique du PictureBox créé dans la grille de mise en forme.
          // A noter que l' "origine" du repère dans le tableau est en haut à gauche.
          tableauJeu.Controls.Add(newPictureBox, j, i);
        }
      }
    }
    #endregion

    #region TypeEtat
    enum TypeEtat
    {
      NONE,
      GELE,
      CARRE,
      LIGNE,
      T,
      L,
      J,
      S,
      Z
    }
    #endregion

    #region Code à développer
    /// <summary>
    /// Faites ici les appels requis pour vos tests unitaires.
    /// </summary>
    void ExecuterTestsUnitaires()
    {
      ExecuterTestABC();
      // A compléter...
    }

    // A renommer et commenter!
    void ExecuterTestABC()
    {
      // Mise en place des données du test

      // Exécuter de la méthode à tester

      // Validation des résultats

      // Clean-up
    }

    #endregion

    #region configDuJeuToolStripMenuItem_Click
    private void configurationDuJeuToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region configurationToolStripMenuItem_Clicl
    //<scloutier>
    public void configurationToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormConfiguration config = new FormConfiguration(this);
      config.numericUpDown1.Value = nbLignes;
      config.numericUpDown2.Value = nbColonnes;
      config.ShowDialog();
    }
    //</scloutier>
    #endregion

    #region quittezToolStripMenuItem_Click
    //<scloutier>
    private void quittezToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
    //</scloutier>
    #endregion

    #region réinitialiséPartieToolStripMenuItem_Click
    //<scloutier>
    private void réinitialiséPartieToolStripMenuItem_Click(object sender, EventArgs e)
    {
      btnStart.Enabled = true;
      InitialiserSurfaceDeJeu(nbLignes = 20, nbColonnes = 10);
      GenererTableauEtat(nbLignes = 20, nbColonnes = 10);
      ReinitialiserPictureBox();
      ligneCourante = 0;
      colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
      timer1.Stop();
    }
    //</scloutier>
    #endregion

    #region InitialiserPieceDansTableau
    //<scloutier>
    void InitialiserPieceDansTableau(TypeEtat randomPiece)
    {
      for (int i = 0; i < blocActifY.Length; i++)
      {
        tableauEtats[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]] = randomPiece;
        if (randomPiece == TypeEtat.CARRE)
        {
          toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Yellow;
        }
        else if (randomPiece == TypeEtat.LIGNE)
        {
          toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Blue;
        }
        else if (randomPiece == TypeEtat.T)
        {
          toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Purple;
        }
        else if (randomPiece == TypeEtat.L)
        {
          toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Green;
        }
        else if (randomPiece == TypeEtat.J)
        {
          toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.OrangeRed;
        }
        else if (randomPiece == TypeEtat.S)
        {
          toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Red;
        }
        else // Bloc Z
        {
          toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Pink;
        }
      }
    }
    //</scloutier>
    #endregion

    #region GenererPieceAleatoire
    // <scloutier>
    TypeEtat GenererPieceAleatoire()
    {
      Random rnd = new Random();
      TypeEtat randomPiece = (TypeEtat)rnd.Next(2, 9);

      if (randomPiece == TypeEtat.CARRE) //Si bloc carré
      {
        //PositionY
        blocActifY[0] = 0;
        blocActifY[1] = 0;
        blocActifY[2] = 1;
        blocActifY[3] = 1;
        //PositionX
        blocActifX[0] = 0;
        blocActifX[1] = 1;
        blocActifX[2] = 0;
        blocActifX[3] = 1;
      }
      else if (randomPiece == TypeEtat.LIGNE) //Si bloc ligne
      {
        //PositionY
        blocActifY[0] = 0;
        blocActifY[1] = 0;
        blocActifY[2] = 0;
        blocActifY[3] = 0;
        //PositionX
        blocActifX[0] = 0;
        blocActifX[1] = 1;
        blocActifX[2] = 2;
        blocActifX[3] = 3;
      }

      else if (randomPiece == TypeEtat.T) //Si bloc T
      {
        //PositionY
        blocActifY[0] = 0;
        blocActifY[1] = 1;
        blocActifY[2] = 1;
        blocActifY[3] = 1;
        //PositionX
        blocActifX[0] = 1;
        blocActifX[1] = 0;
        blocActifX[2] = 1;
        blocActifX[3] = 2;
      }
      else if (randomPiece == TypeEtat.L)
      {
        //PositionY
        blocActifY[0] = 0;
        blocActifY[1] = 1;
        blocActifY[2] = 2;
        blocActifY[3] = 2;
        //PositionX
        blocActifX[0] = 0;
        blocActifX[1] = 0;
        blocActifX[2] = 0;
        blocActifX[3] = 1;
      }
      else if (randomPiece == TypeEtat.J)
      {
        //PositionY
        blocActifY[0] = 0;
        blocActifY[1] = 1;
        blocActifY[2] = 2;
        blocActifY[3] = 2;
        //PositionX
        blocActifX[0] = 1;
        blocActifX[1] = 1;
        blocActifX[2] = 1;
        blocActifX[3] = 0;
      }
      else if (randomPiece == TypeEtat.S)
      {
        //PositionY
        blocActifY[0] = 1;
        blocActifY[1] = 1;
        blocActifY[2] = 0;
        blocActifY[3] = 0;
        //PositionX
        blocActifX[0] = 0;
        blocActifX[1] = 1;
        blocActifX[2] = 1;
        blocActifX[3] = 2;
      }
      else // TypeEtat.Z
      {
        //PositionY
        blocActifY[0] = 0;
        blocActifY[1] = 0;
        blocActifY[2] = 1;
        blocActifY[3] = 1;
        //PositionX
        blocActifX[0] = 0;
        blocActifX[1] = 1;
        blocActifX[2] = 1;
        blocActifX[3] = 2;
      }

      return randomPiece;
    }
    //</scloutier>
    #endregion

    #region GenererTableauEtat
    //<scloutier>
    /// <summary>
    /// 
    /// </summary>
    /// <param name="nbLignes"></param>
    /// <param name="nbColonnes"></param>
    public void GenererTableauEtat(int nbLignes, int nbColonnes)
    {
      tableauEtats = new TypeEtat[nbLignes, nbColonnes];

      for (int i = 0; i < nbLignes; i++)
      {
        for (int j = 0; j < nbColonnes; j++)
        {
          tableauEtats[i, j] = TypeEtat.NONE; // Initialisation au type -> None
        }
      }
    }
    //</scloutier>
    #endregion

    #region EffacerLigne
    public void EffacerLigne(int nbDeLaLigneComplete)
    {
      for (int i = 0; i < tableauEtats.GetLength(1); i++)
      {
        tableauEtats[nbDeLaLigneComplete, i] = (int)TypeEtat.NONE;
        toutesImagesVisuelles[nbDeLaLigneComplete, i].BackColor = Color.Black;
      }
    }
    #endregion

    #region VerifierLigne
    //<aouellet>
    public List<int> VerifierLigne()
    {
      int nbLigneComplete = 0;
      bool ligneEstComplete = false;
      int compteurSiLigneComplete = 0;
      List<int> lignesCompleter = new List<int>();
      for (int i = 0; i < tableauEtats.GetLength(0); i++)
      {
        for (int j = 0; j < tableauEtats.GetLength(1); j++)
        {
          if (tableauEtats[i, j] == TypeEtat.GELE)
          {
            compteurSiLigneComplete++;
            if (compteurSiLigneComplete == tableauEtats.GetLength(1))
            {
              ligneEstComplete = true;
              compteurSiLigneComplete = 0;
              if (ligneEstComplete == true)
              {
                nbLigneComplete = i;
                lignesCompleter.Add(i);
              }
            }
          }
          else
          {
            nbLigneComplete = 0;
          }
        }
        compteurSiLigneComplete = 0;
      }
      return lignesCompleter;
    }
    #endregion


    void RotationPiece()
    {

    }

    #region ReinitialiserPictureBox
    ////<scloutier>
    void ReinitialiserPictureBox()
    {
      for (int i = 0; i < tableauEtats.GetLength(0); i++)
      {
        for (int j = 0; j < tableauEtats.GetLength(1); j++)
        {
          toutesImagesVisuelles[i, j].BackColor = Color.Black;
        }
      }
    }
    //</scloutier>
    #endregion

    #region btnStart_Click
    //<scloutier>
    private void btnStart_Click(object sender, EventArgs e)
    {
      partieEnCours = true;
      btnStart.Enabled = false;
      ReinitialiserPictureBox();
      ligneCourante = 0;
      colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
      GenererTableauEtat(nbLignes, nbColonnes);
      pieceTableau = GenererPieceAleatoire();
      InitialiserPieceDansTableau(pieceTableau);
      timer2.Start();
      timer1.Start();

    }
    //</scloutier>
    #endregion

    #region Deplacement
    //<scloutier>
    enum Deplacement
    {
      DESCENDRE,
      DROITE,
      GAUCHE,
      ROTATION_HORAIRE,
      ROTATION_ANTIHORAIRE,
      MONTER
    }
    //</scloutier>
    #endregion

    #region KeyPressDeplacement
    //<scloutier>
    private void KeyPressDeplacement(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
      {
        mouvement = Deplacement.DESCENDRE;
        VerifierDeplacement(mouvement);
        if (deplacementPossible == true)
        {
          EnleverAncienBloc();
          ligneCourante++;
          InitialiserPieceDansTableau(pieceTableau);
        }
      }
      else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
      {
        mouvement = Deplacement.DROITE;
        VerifierDeplacement(mouvement);
        if (deplacementPossible == true)
        {

          EnleverAncienBloc();
          colonneCourante++;
          InitialiserPieceDansTableau(pieceTableau);
        }
      }
      else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
      {
        mouvement = Deplacement.GAUCHE;
        VerifierDeplacement(mouvement);
        if (deplacementPossible == true)
        {
          EnleverAncienBloc();
          colonneCourante--;
          InitialiserPieceDansTableau(pieceTableau);
        }
      }
      else if (e.KeyCode == Keys.E)
      {

        mouvement = Deplacement.ROTATION_HORAIRE;
        VerifierDeplacement(mouvement);
        if (deplacementPossible == true)
        {
          EnleverAncienBloc();
          int temp = 0;
          for (int j = 0; j < blocActifX.Length; j++)
          {
            temp = -blocActifY[j];
            blocActifY[j] = blocActifX[j];
            blocActifX[j] = temp;
          }
          InitialiserPieceDansTableau(pieceTableau);
        }
      }
      else if (e.KeyCode == Keys.Q)
      {

        mouvement = Deplacement.ROTATION_ANTIHORAIRE;
        VerifierDeplacement(mouvement);
        if (deplacementPossible == true)
        {
          EnleverAncienBloc();
          int temp = 0;
          for (int j = 0; j < blocActifX.Length; j++)
          {
            temp = -blocActifX[j];
            blocActifX[j] = blocActifY[j];
            blocActifY[j] = temp;
          }
          InitialiserPieceDansTableau(pieceTableau);
        }
      }
    }
    //</scloutier>
    #endregion

    bool VerifierDeplacement(Deplacement sens)
    {
      if (sens == Deplacement.DESCENDRE)
      {
        for (int i = 0; i < blocActifY.Length; i++)
        {
          if ((ligneCourante + 1 + blocActifY[i] <= tableauEtats.GetLength(0) - 1) &&
                 (int)tableauEtats[ligneCourante + 1 + blocActifY[i], colonneCourante + blocActifX[i]] <= tableauEtats.GetLength(0) - 1
                      && tableauEtats[ligneCourante + 1 + blocActifY[i], colonneCourante + blocActifX[i]] != TypeEtat.GELE)
          {
            deplacementPossible = true;
          }
          else
          {
            deplacementPossible = false;
            GeleBlocs();
            return deplacementPossible;
          }
        }
      }
      else if (sens == Deplacement.GAUCHE)
      {
        for (int j = 0; j < blocActifX.Length; j++)
        {
          if (colonneCourante - 1 + blocActifX[j] < 0)
          {
            deplacementPossible = false;
            return false;
          }
          else if (tableauEtats[ligneCourante + blocActifY[j], colonneCourante - 1 + blocActifX[j]] == TypeEtat.GELE)
          {
            deplacementPossible = false;
            return false;
          }
          else
          {
            deplacementPossible = true;
          }
        }
      }

      else if (sens == Deplacement.DROITE)
      {
        for (int j = 0; j < blocActifX.Length; j++)
        {
          if (colonneCourante + 1 + blocActifX[j] >= tableauEtats.GetLength(1))
          {
            deplacementPossible = false;
            return false;
          }
          else if (tableauEtats[ligneCourante + blocActifY[j], colonneCourante + 1 + blocActifX[j]] == TypeEtat.GELE)
          {
            deplacementPossible = false;
            return false;
          }
          else
          {
            deplacementPossible = true;
          }
        }
      }
      else if (sens == Deplacement.ROTATION_HORAIRE)
      {
        for (int i = 0; i < blocActifX.Length; i++)
        {
          nouveauBlocActifX[i] = -blocActifY[i];
          nouveauBlocActifY[i] = blocActifX[i];

          if (ligneCourante + blocActifX[i] > tableauEtats.GetLength(0) - 1 || ligneCourante + blocActifX[i] < 0 || colonneCourante - blocActifY[i] > tableauEtats.GetLength(1) - 1 || colonneCourante - blocActifY[i] < 0)
          {
            deplacementPossible = false;
            return false;
          }
          else if (tableauEtats[ligneCourante + blocActifX[i], colonneCourante - blocActifY[i]] == TypeEtat.GELE)
          {
            deplacementPossible = false;
            return false;
          }
          else if (pieceTableau == TypeEtat.CARRE)
          {
            deplacementPossible = false;
            return false;
          }
        }
      }
      else if (sens == Deplacement.ROTATION_ANTIHORAIRE)
      {
        for (int i = 0; i < blocActifX.Length; i++)
        {
          nouveauBlocActifX[i] = blocActifY[i];
          nouveauBlocActifY[i] = -blocActifX[i];

          if (ligneCourante - blocActifX[i] < tableauEtats.GetLength(1) || ligneCourante + blocActifX[i] < 0 || colonneCourante - blocActifY[i] > tableauEtats.GetLength(1) - 1 || colonneCourante - blocActifY[i] < 0)
          {
            deplacementPossible = false;
            return false;
          }
          else if (tableauEtats[ligneCourante - blocActifX[i], colonneCourante + blocActifY[i]] == TypeEtat.GELE)
          {
            deplacementPossible = false;
            return false;
          }
          else if (pieceTableau == TypeEtat.CARRE)
          {
            deplacementPossible = false;
            return false;
          }
        }
      }
      return deplacementPossible;
    }

    void GeleBlocs()
    {
      for (int i = 0; i < blocActifY.Length; i++)
      {
        tableauEtats[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]] = TypeEtat.GELE;
        toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Gray;
      }
      pieceTableau = GenererPieceAleatoire();                              //Il faudrait possiblement bouger ce code
      ligneCourante = 0;
      colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
      InitialiserPieceDansTableau(pieceTableau);
    }

    void EnleverAncienBloc()
    {
      for (int i = 0; i < blocActifY.Length; i++)
      {
        for (int j = 0; j < blocActifX.Length; j++)
        {
          if (tableauEtats[ligneCourante + blocActifY[i], colonneCourante + blocActifX[j]] != TypeEtat.NONE)
          {
            tableauEtats[ligneCourante + blocActifY[i], colonneCourante + blocActifX[j]] = TypeEtat.NONE;
            toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[j]].BackColor = Color.Black;
          }
        }
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      VerifierFinDePartie();
      VerifierDeplacement(Deplacement.DESCENDRE);
      if (deplacementPossible == true)
      {
        EnleverAncienBloc();
        ligneCourante++;
        InitialiserPieceDansTableau(pieceTableau);
        List<int> nbLigneADecaler = VerifierLigne();
        foreach (int ligne in nbLigneADecaler)
        {
          EffacerLigne(ligne);
          DecalerLignes(ligne);
          DessinerTableau();
        }

      }
    }

    void VerifierFinDePartie()
    {
      if (tableauEtats[1, colonneCourante / 2] == TypeEtat.GELE)
      {
        FormStatistique stats = new FormStatistique(this);
        stats.ShowDialog();
      }
    }

    public void timer2_Tick(object sender, EventArgs e)
    {
      nbDeSeconde++;
    }

    void DecalerLignes(int nbLigneADecaler)
    {
      for (int i = nbLigneADecaler; i > 0; i--)
      {
        for (int j = 0; j < tableauEtats.GetLength(1); j++)
        {
          if (tableauEtats[i, j] == TypeEtat.GELE || tableauEtats[i, j] == TypeEtat.NONE)
          {
            tableauEtats[i, j] = tableauEtats[i - 1, j];
          }
        }
      }
      for (int x = 0; x < tableauEtats.GetLength(1); x++)
      {
        tableauEtats[0, x] = TypeEtat.NONE;
      }
    }

    void DessinerTableau()
    {
      for (int i = 0; i < tableauEtats.GetLength(0); i++)
      {
        for (int j = 0; j < tableauEtats.GetLength(1); j++)
        {
          if (tableauEtats[i, j] == TypeEtat.CARRE)
          {
            toutesImagesVisuelles[i, j].BackColor = Color.Yellow;
          }
          else if (tableauEtats[i, j] == TypeEtat.NONE)
          {
            toutesImagesVisuelles[i, j].BackColor = Color.Black;
          }
          else if (tableauEtats[i, j] == TypeEtat.GELE)
          {
            toutesImagesVisuelles[i, j].BackColor = Color.Gray;
          }
          else if (tableauEtats[i, j] == TypeEtat.LIGNE)
          {
            toutesImagesVisuelles[i, j].BackColor = Color.Blue;
          }
          else if (tableauEtats[i, j] == TypeEtat.S)
          {
            toutesImagesVisuelles[i, j].BackColor = Color.Red;
          }
          else if (tableauEtats[i, j] == TypeEtat.Z)
          {
            toutesImagesVisuelles[i, j].BackColor = Color.Pink;
          }
          else if (tableauEtats[i, j] == TypeEtat.J)
          {
            toutesImagesVisuelles[i, j].BackColor = Color.OrangeRed;
          }
          else if (tableauEtats[i, j] == TypeEtat.L)
          {
            toutesImagesVisuelles[i, j].BackColor = Color.Green;
          }
          else
          {
            toutesImagesVisuelles[i, j].BackColor = Color.Purple;
          }
        }
      }

    }
  }
}
