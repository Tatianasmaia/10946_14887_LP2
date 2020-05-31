using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <param name="ni"></param>
        /// <param name="d"></param>
        public Utente(string n, string r, string s, int i, int ni, DateTime d) : base(n, r, s, i, ni, d)
        {
            totalUtentes++;
            numUtente = totalUtentes;
            infetado = true;
        }

        #endregion

        #region Propriedades

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
