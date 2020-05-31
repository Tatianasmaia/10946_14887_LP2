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
 * Camada DataLayer
 * 
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using BO;

namespace DL
{
    [Serializable]
    public class Utentes
    {

        //Atributos da classe
       
        #region Estado

        //Lista de utentes (privada)
        private static List<Utente> listaUtentes;           //Lista que guarda os utentes infetados
        private static List<Utente> historicoUtentes;       //Lista que guarda os utentes que foram registados previamente e já não estão infetados
        private static List<Utente> listaAuxiliar;

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor default da classe
        /// Cria as listas ao executar o programa
        /// </summary>
        static Utentes()
        {

            listaUtentes = new List<Utente>();
            historicoUtentes = new List<Utente>();
            listaAuxiliar = new List<Utente>();
        }

        #endregion


        #region Metodos_Da_Classe

        /// <summary>
        /// Recebe um utente(u) do tipo Utente.
        /// Caso o utente já estiver inserido na lista irá retornar false.
        /// Caso o utente tenha sido adicionado com sucesso é retornado true;
        /// </summary>
        /// <param name="p"></param>
        public static bool InsereUtente(Utente u)
        {
            //Caso o utente já tenha sido inserido
            if (listaUtentes.Contains(u)) return false;

            //Caso seja possível adicionar o utente à lista
            //numUtente++;
            listaUtentes.Add(u);
            return true;
        }

        
        /// <summary>
        /// Função que remove infetado. Quando é encontrado o utente pedido, este é removido da lista de utentes infetados e é adicionado à lista que contém o histórico de utentes
        /// </summary>
        /// <param name="p"></param>
        /// <returns>0- se a lista estiver nula
        ///          1- Caso o cliente tenha sido removido da lista de infetados com sucesso
        ///          2- Se o id inserido não estiver inserido na lista</returns>
        public static int RemoveUtente(int num)
        {
            if (listaUtentes.Count == 0)
            {
                return 0;
            }
            else
            {
                foreach (Utente ut in listaUtentes)
                {
                    if (ut.NumUtente == num)
                    {
                        ut.Infetado = false;
                        listaUtentes.Remove(ut);
                        historicoUtentes.Add(ut);
                        return 2;
                    }
                }
            }

            return 1;
        }

        /// <summary>
        /// Função que
        /// </summary>
        /// <param name="p"></param>
        /// <returns>0- se a lista estiver nula
        ///          1- Caso o cliente tenha sido removido da lista de infetados com sucesso
        ///          2- Se o id inserido não estiver inserido na lista</returns>
        public static Utente PesquisaUtente(int nif)
        {
           
            foreach (Utente ut in listaUtentes)
            {
                if (ut.Nif == nif)
                {
                    return ut;
                }
            }

            return null;
        }

        /// <summary>
        /// Esta função irá receber o número de utente que já tenha sido registado mas já não está infetado
        /// </summary>
        /// <param name="numU"></param>
        /// <returns>0-> caso a lista esteja vazia
        ///          1- caso o número de utente inserido não esteja registado
        ///          2- caso o utente tenha sido alterado ocm sucesso</returns>
        public static int EditaUtente2(int numU)
        {
            if (historicoUtentes.Count == 0)
            {
                return 0;
            }
            else
            {
                foreach (Utente ut in historicoUtentes)
                {
                    if (ut.NumUtente == numU)
                    {
                        ut.Infetado = true;
                        historicoUtentes.Remove(ut);
                        listaUtentes.Add(ut);
                        return 2;
                    }
                }
            }
            

            return 1;
        }

        /// <summary>
        /// Função que faz a verificação do nif do utente, pois não podem haver nifs iguais
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public static bool VerificaNif(int nif)
        {
            foreach(Utente u in listaUtentes)
            {
                if (u.Nif == nif)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Função que verifica o numero de digitos do nif inserido pleo utilizador
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public static bool VerificaDigitos(int nif)
        {        
            int  count = 0;
            
            while (nif > 0)
            {
                nif = nif / 10;
                count++;
            }

            if (count != 9)
            {
                return false;
            }
            else return true;
            
        }

        /// <summary>
        /// Função que, a partir da idade inserida pelo utilizador, insere todos os utentes com essa mesma idade numa lista auxiliar para que seja possivel mostrar
        /// </summary>
        /// <param name="idade"></param>
        /// <returns></returns>
        public static List<Utente> ConsultaIdades(int idade)
        {
            listaAuxiliar.Clear();

            foreach (Utente u in listaUtentes)
            {
                if (u.Idade == idade)
                {
                    listaAuxiliar.Add(u);
                }
            }

            return listaAuxiliar;
        }

        /// <summary>
        /// Função que, a partir da regiao inserida pelo utilizador, insere todos os utentes com essa mesma regiao numa lista auxiliar para que seja possivel mostrar
        /// </summary>
        /// <param name="regiao"></param>
        /// <returns>Dá return á lista auxiliar (mesmo que seja nula)</returns>
        public static List<Utente> ConsultaRegiao(string regiao)
        {
            listaAuxiliar.Clear();

            foreach (Utente u in listaUtentes)
            {
                if (u.Regiao == regiao)
                {
                    listaAuxiliar.Add(u);
                }
            }

            return listaAuxiliar;
        }

        /// <summary>
        /// A partir do sexo inserido pleo utilizador, esta função adiciona todos os utentes desse sexo e adiciona à lista auxiliar
        /// </summary>
        /// <param name="sexo"></param>
        /// <returns>Retorna a listaAuxiliar</returns>
        public static List<Utente> ConsultaSexo(string sexo)
        {
            listaAuxiliar.Clear();

            foreach (Utente u in listaUtentes)
            {
                if (u.Sexo == sexo)
                {
                    listaAuxiliar.Add(u);
                }
            }

            return listaAuxiliar;
        }

        /// <summary>
        /// Função que mostra a lista de utentes (onde estão inseridos todos os utentes infetados)
        /// </summary>
        /// <returns>listaUtentes</returns>
        public static List<Utente> ListarInfetados()
        {
            return listaUtentes;
        }

        /// <summary>
        /// Função que retorna a lista do historico de utentes (onde estão inseridos todos os utentes que já não estão infetados)
        /// </summary>
        /// <returns>listaUtentes</returns>
        public static List<Utente> ListarHistorico()
        {
            return historicoUtentes;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param =""></param>
        /// <returns></returns>
        //public static int Editar()
        //{

        //}


        #endregion

        #region Metodos_Privados


        /// <summary>
        /// Guarda os dados binários no ficheiro
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool Save(string fileName)
        {
            try
            {
                Stream s = File.Open(fileName, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, listaUtentes);
                s.Flush();
                s.Close();
                s.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        /// <summary>
        /// Guarda os dados binários no ficheiro
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool SaveHistoricoU(string fileName)
        {
            try
            {
                Stream s = File.Open(fileName, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, historicoUtentes);
                s.Flush();
                s.Close();
                s.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        /// <summary>
        /// Carrega os dados
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool Load(string fileName)
        {
            try
            {
                Stream s = File.Open(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                listaUtentes = (List<Utente>)b.Deserialize(s);
                s.Flush();
                s.Close();
                s.Dispose();
                return true;
            }
            catch
            {
                throw new Exception("Erro");
            }
        }

        /// <summary>
        /// Carrega os dados d
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool LoadHistoricoU(string fileName)
        {
            try
            {
                Stream s = File.Open(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                historicoUtentes = (List<Utente>)b.Deserialize(s);
                s.Flush();
                s.Close();
                s.Dispose();
                return true;
            }
            catch
            {
                throw new Exception("Erro");
            }
        }

        #endregion

    }
}
