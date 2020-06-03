/*
 * Trabalho Prático - Linguagem de Programação II
 * 
 * Realizado por: Joana Jesus (nrº 10946) e Tatiana Maia (nrº 14887)
 * 
 * 
 * Este trabalho tem como objetivo gerir pessoas infetadas numa situação de crise de saúde pública. 
 * Deste modo, o sistema irá permitir inserir novos casos, editar e remover casos já existentes, assim como a consulta dos mesmos através dos vários tipos de informação do utente.
 */

 /*
  * Camada Business Objects
  * Esta camada possui as classes
  */



using System;

namespace BO
{

    /// <summary>
    /// Descrição do que é uma pessoa
    /// </summary>
    [Serializable]
    public class Pessoa
    {
        //Atributos da classe
        #region Estado

        int idade, nif;
        string nome, regiao;
        bool feminino;

        #endregion


        #region Construtor
        //Métodos usados na criação de novos objectos
        /// <summary>
        /// Construtor com valores por defeito/omissão
        /// Executado quando fizer new Pessoa
        /// </summary>
        public Pessoa()
        {
            nome = "";
            regiao = "";
            idade = -1;
            nif = -1;
            feminino = true;
        }

        /// <summary>
        /// Construtor que recebe valores externos
        /// Executado quando fizer new Pessoa
        /// </summary>
        /// <param name="n">Nome da Pessoa</param>
        /// <param regiao="r">Regiao da Pessoa</param>
        /// <param sexo="s">Sexo da Pessoa</param>
        /// <param name="i">Idade da Pessoa</param>
        /// <param nif="ni">Nif da Pessoa</param>
        public Pessoa(string n, string r, bool f, int i, int ni)
        {
            nome = n;
            regiao = r;
            idade = i;
            nif = ni;
            feminino = true;
        }

        #endregion


        #region Propriedades

        /// <summary>
        /// Manipula o atributo "idade"
        /// int idade;
        /// </summary>
        public int Idade
        {
            get => idade;
            set => idade = value;
        }

        /// <summary>
        /// Manipula o atributo "nif"
        /// int nif;
        /// </summary>
        public int Nif
        {
            get { return nif; }
            set { nif = value; }
        }

        /// <summary>
        /// Manipula o atributo "nome"
        /// string nome;
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Manipula o atributo "regiao"
        /// string regiao;
        /// </summary>
        public string Regiao
        {
            get { return regiao; }
            set { regiao = value; }
        }

        /// <summary>
        /// Manipula o atributo "feminino"
        /// bool feminino;
        /// </summary>
        public bool Feminino
        {
            get { return feminino; }
            set { feminino = true; }
        }



        #endregion
    }
}
