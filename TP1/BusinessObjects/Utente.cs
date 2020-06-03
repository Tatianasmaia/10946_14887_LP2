using System;

namespace BO
{

    /// <summary>
    /// Classe Utente que herda da classe Pessoa
    /// </summary>
    [Serializable]
    public class Utente : Pessoa
    {
        #region Estado

        int numUtente;
        [NonSerialized]
        bool infetado;
        static int totalUtentes=0;

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor com valores por defeito/omissão
        /// </summary>
        public Utente() : base()
        {
            totalUtentes++;
            infetado = true;
            numUtente = totalUtentes;

        }

        /// <summary>
        /// Executado quando houver "new"
        /// </summary>
        /// <param name="n">nome</param>
        /// <param name="r">regiao</param>
        /// <param name="f">feminino </param>
        /// <param name="i">idade</param>
        /// <param name="ni">nif</param>
        public Utente(string n, string r, bool f, int i, int ni) : base(n, r, f, i, ni)
        {
            totalUtentes++;
            numUtente = totalUtentes;
            infetado = true;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Manipula o atributo infetado
        /// </summary>
        public bool Infetado
        {
            set { infetado = true; }
        }

        /// <summary>
        /// Manipula o atributo "numUtente"
        /// </summary>
        public int NumUtente
        {
            get { return numUtente; }
            set { numUtente = value; }
        }

       
        #endregion
    }
}
