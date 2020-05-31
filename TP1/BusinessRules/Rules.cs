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
        public static bool InsereUtente(Utente u)
        {
            return Utentes.InsereUtente(u);
        }

        /// <summary>
        /// Função que remove infetado
        /// </summary>
        /// <param name="num">numero do utente a remover</param>
        /// <returns>0- se a lista estiver nula
        ///          1- Caso o cliente tenha sido removido da lista de infetados com sucesso
        ///          2- Se o id inserido não estiver inserido na lista</returns>
        public static int RemoveUtente(int num)
        {
            return Utentes.RemoveUtente(num);
        }

        /// <summary>
        /// Esta função faz a ligação entre as camadas presentation layer e Data layer
        /// </summary>
        /// <param name="nif">nif do utente a pesquisar</param>
        /// <returns>false-> Caso o utente já tenha sido inserido
        ///           true-> Caso o utente tenha sido inserido com sucesso</returns>
        public static Utente PesquisaUtente(int nif)
        {
            return Utentes.PesquisaUtente(nif);
        }

        /// <summary>
        /// Função que insere um utente já registado na lista de infetados
        /// </summary>
        /// <param name="numU"></param>
        /// <returns></returns>
        public static int EditaUtente2(int numU)
        {
            return Utentes.EditaUtente2(numU);
        }

        /// <summary>
        /// Função que verifica digitos do nif
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public static bool VerificaDigitos(int nif)
        {
            return Utentes.VerificaDigitos(nif);
        }

        /// <summary>
        /// função que verifica se o nif inserido já está registado
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public static bool VerificaNif(int nif)
        {
            return Utentes.VerificaNif(nif);
        }

        /// <summary>
        /// função que consulta os utentes através da idade inserida pelo utilizador
        /// </summary>
        /// <param name="idade"></param>
        /// <returns></returns>
        public static List<Utente> ConsultaIdades(int idade)
        {
            return Utentes.ConsultaIdades(idade);
        }

        /// <summary>
        /// Função que consulta os utentes através da regiao inserida pelo utilizador
        /// </summary>
        /// <param name="regiao"></param>
        /// <returns></returns>
        public static List<Utente> ConsultaRegiao(string regiao)
        {
            return Utentes.ConsultaRegiao(regiao);
        }

        /// <summary>
        /// Função que consulta os utentes através do sexo introduzido pelo utilizador
        /// </summary>
        /// <param name="sexo"></param>
        /// <returns></returns>
        public static List<Utente> ConsultaSexo(string sexo)
        {
            return Utentes.ConsultaSexo(sexo);
        }

        /// <summary>
        /// Função que lista a lista de infetados
        /// </summary>
        /// <returns></returns>
        public static List<Utente> ListarInfetados()
        {
            return Utentes.ListarInfetados();
        }

        /// <summary>
        /// Função que lista o historico de utentes
        /// </summary>
        /// <returns></returns>
        public static List<Utente> ListarHistorico()
        {
            return Utentes.ListarHistorico();
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
        public static bool SaveHistoricoU(string fileName)
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
        public static bool LoadHistoricoU(string fileName)
        {
            return Utentes.Load(fileName);
        }

        
    }
}
