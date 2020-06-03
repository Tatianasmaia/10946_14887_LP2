/*
 * Trabalho Prático - Linguagem de Programação II
 * 
 * Realizado por: Joana Jesus (nrº 10946) e Tatiana Maia (nrº 14887)
 * 
 * 
 * Este trabalho tem como objetivo gerir pessoas infetadas numa situação de crise de saúde pública. 
 * Deste modo, o sistema irá permitir inserir novos casos, editar e remover casos já existentes, assim como a consulta dos mesmos através dos vários tipos de informação do utente.
 * 
 * ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 * 
 * Camada: Regras de Negócio
 * Camada que consegue aceder aos métodos da camada de dados (DataLayer)
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using BO;

namespace BR
{
    public class Rules
    {
        /// <summary>
        /// Esta função faz a ligação entre as camadas presentation layer e Data layer
        /// </summary>
        /// <param name="u">utente</param>
        /// <returns>false-> Caso o utente já tenha sido inserido
        ///           true-> Caso o utente tenha sido inserido com sucesso</returns>
        public static bool InsertPatient(Utente u)
        {
            return Utentes.InsertPatient(u);
        }

        /// <summary>
        /// Função que verifica as informações do utente a registar
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static int VerifyPatient(Utente u)
        {
            
            return Utentes.VerifyPatient(u);
            
        }

        /// <summary>
        /// Função que remove infetado
        /// </summary>
        /// <param name="num">numero do utente a remover</param>
        /// <returns>0- se a lista estiver nula
        ///          1- Caso o cliente tenha sido removido da lista de infetados com sucesso
        ///          2- Se o id inserido não estiver inserido na lista</returns>
        public static int RemovePatient(int num)
        {
            return Utentes.RemovePatient(num);
        }

        /// <summary>
        /// Esta função faz a ligação entre as camadas presentation layer e Data layer
        /// </summary>
        /// <param name="nif">nif do utente a pesquisar</param>
        /// <returns>false-> Caso o utente já tenha sido inserido
        ///           true-> Caso o utente tenha sido inserido com sucesso</returns>
        public static List<Utente> SearchPatient(int nif)
        {
            return Utentes.SearchPatient(nif);
        }

        public static int EditInformation(string nome, string idade, string nif, string regiao, bool f, bool m, int numU)
        {
            return Utentes.EditInformation(nome, idade, nif, regiao, f, m, numU);
        }

        /// <summary>
        /// Função que insere um utente já registado na lista de infetados
        /// </summary>
        /// <param name="numU"></param>
        /// <returns></returns>
        public static int EditPatient2(int numU)
        {
            return Utentes.EditPatient2(numU);
        }

        /// <summary>
        /// Função que verifica digitos do nif
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public static bool VerifyDigits(int nif)
        {
            return Utentes.VerifyDigits(nif);
        }

        /// <summary>
        /// função que verifica se o nif inserido já está registado
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public static int VerifyNif(int nif)
        {
            return Utentes.VerifyNif(nif);
        }

        /// <summary>
        /// função que consulta os utentes através da idade inserida pelo utilizador
        /// </summary>
        /// <param name="idade"></param>
        /// <returns></returns>
        public static List<Utente> ConsultAges(int idade)
        {
            return Utentes.ConsultAges(idade);
        }

        /// <summary>
        /// Função que consulta os utentes através da regiao inserida pelo utilizador
        /// </summary>
        /// <param name="regiao"></param>
        /// <returns></returns>
        public static List<Utente> ConsultRegion(string regiao)
        {
            return Utentes.ConsultRegion(regiao);
        }

        /// <summary>
        /// Função que consulta os utentes através do sexo introduzido pelo utilizador
        /// </summary>
        /// <param name="sexo"></param>
        /// <returns></returns>
        public static List<Utente> ConsultGender(bool feminino)
        {
            return Utentes.ConsultGender(feminino);
        }

        /// <summary>
        /// Função que lista a lista de infetados
        /// </summary>
        /// <returns></returns>
        public static List<Utente> ListInfected()
        {
            return Utentes.ListInfected();
        }

        /// <summary>
        /// Função que lista o historico de utentes
        /// </summary>
        /// <returns></returns>
        public static List<Utente> ListHistoric()
        {
            return Utentes.ListHistoric();
        }

        //FALTA EXCEPTIONS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool Save(string fileName)
        {
            return Utentes.Save(fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool SaveHistoricP(string fileName)
        {
            return Utentes.Save(fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool Load(string fileName)
        {
            return Utentes.Load(fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool LoadHistoricP(string fileName)
        {
            return Utentes.Load(fileName);
        }

        
    }
}
