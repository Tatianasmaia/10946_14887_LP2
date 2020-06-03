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

        private const string DATAFILE = "ListaUtentes.dat";
        private const string DATAFILE2 = "HistoricoUtentes.dat";

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

            //Load(DATAFILE);
            //LoadHistoricoU(DATAFILE2);
            
        }

        #endregion


        #region Metodos_Da_Classe

        /// <summary>
        /// Função que verifica se o utente inserido pleo utilizador é válido
        /// </summary>
        /// <param name="u">utente do tipo Utente</param>
        /// <returns>
        /// 0- Caso a idade inserida não seja válida
        /// 1- Caso o número de dígitos não seja válido
        /// 2- Caso o nif inserido já esteja registado
        /// 3- Caso o utente tenha sido adicionado à lista com sucesso</returns>
        public static int VerifyPatient(Utente u)
        {
            bool aux;


            //Verificação da idade
            if (u.Idade < 0 || u.Idade > 110)
            {
                return 0;
            }

            //Verifica se o nif tem 9 digitos
            do
            {
                aux = VerifyDigits(u.Nif);
                if (aux == false)
                {
                    return 1;
                }
            }
            while (aux == false);


            //Verifica se o nif já foi inserido por outro utente
            foreach(Utente ut in listaUtentes)
            {
                if (u.Nif == ut.Nif)
                {
                    return 2;
                }
            }

            InsertPatient(u);
            return 3;
        }

        /// <summary>
        /// Recebe um utente(u) do tipo Utente.
        /// Caso o utente já estiver inserido na lista irá retornar false.
        /// Caso o utente tenha sido adicionado com sucesso é retornado true;
        /// </summary>
        /// <param name="p"></param>
        public static bool InsertPatient(Utente u)
        {
            //Caso o utente já tenha sido inserido
            if (listaUtentes.Contains(u)) return false;

            //Caso seja possível adicionar o utente à lista
            listaUtentes.Add(u);

            //Save(DATAFILE);

            return true;
        }

        
        /// <summary>
        /// Função que remove infetado. Quando é encontrado o utente pedido, este é removido da lista de utentes infetados e é adicionado à lista que contém o histórico de utentes
        /// </summary>
        /// <param name="p"></param>
        /// <returns>0- se a lista estiver nula
        ///          1- Caso o cliente tenha sido removido da lista de infetados com sucesso
        ///          2- Se o id inserido não estiver inserido na lista</returns>
        public static int RemovePatient(int num)
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

            //Save(DATAFILE);

            return 1;
        }

        /// <summary>
        /// Função que
        /// </summary>
        /// <param name="p"></param>
        /// <returns>0- se a lista estiver nula
        ///          1- Caso o cliente tenha sido removido da lista de infetados com sucesso
        ///          2- Se o id inserido não estiver inserido na lista</returns>
        public static List<Utente> SearchPatient(int nif)
        {
            listaAuxiliar.Clear();

            foreach (Utente ut in listaUtentes)
            {
                if (ut.Nif == nif)
                {
                    listaAuxiliar.Add(ut);
                    return listaAuxiliar;
                }
            }

            return null;
        }

        /// <summary>
        /// Função que edita um utente infetado
        /// </summary>
        /// <param name="nome">nome do utente</param>
        /// <param name="idade">idade do utente</param>
        /// <param name="nif">nif do utente</param>
        /// <param name="regiao">regiao do utente</param>
        /// <param name="sexo">sexo do utente</param>
        /// <param name="numU">numero de utente</param>
        /// <returns></returns>
        public static int EditInformation(string nome, string idade, string nif, string regiao, bool f, bool m, int numU)
        {
            //Caso nenhuma textBox tenha sido preenchida dá return a 0
            if (string.IsNullOrWhiteSpace(nome) && string.IsNullOrWhiteSpace(idade) && string.IsNullOrWhiteSpace(nif) && string.IsNullOrWhiteSpace(regiao) && f == false && m == false) return 0;

            foreach (Utente ut in listaUtentes)
            {
                if (ut.NumUtente == numU)
                {
                    //Verifica se a caixa do nome foi preenchida para fazer a edição do nome
                    if (!string.IsNullOrWhiteSpace(nome))
                    {

                        ut.Nome = nome;

                    }

                    //Verifica se a caixa da idade foi preenchida para fazer a edição da idade
                    if (!string.IsNullOrWhiteSpace(idade))
                    {
                        int idadeAux = Int32.Parse(idade);
                        bool aux = VerifyAge(idadeAux);

                        if (aux == false)
                        {
                            return 1;
                        }
                        else
                        {
                            ut.Idade = idadeAux;
                        }

                    }

                    //Verifica se a caixa do nif foi preenchida para fazer a edição do nif
                    if (!string.IsNullOrWhiteSpace(nif)) 
                    {
                        int nifAux = Int32.Parse(nif);
                        int aux = VerifyNif(nifAux);

                        //Caso o número de digitos não esteja correto
                        if (aux == 0)
                        {
                            return 2;
                        }
                        //Caso o nif já tenha sido inserido por outro utente
                        else if(aux == 1)
                        {
                            return 3;
                        }
                        //Sucesso
                        else if(aux == 2)
                        {
                            ut.Idade = nifAux;
                        }
                    }

                    //Verifica se a caixa da regiao foi preenchida para fazer a edição da regiao
                    if (!string.IsNullOrWhiteSpace(regiao))
                    {
                        ut.Regiao = regiao;
                    }

                    //Se f for verdadeiro, isso implica que o utilizador pretende mudar o sexo para feminino 
                    if(f == true && m == false)
                    {
                        ut.Feminino = false;
                    }
                    //Caso a checkBox do masculino estiver selecionada, significa que o utilizador pretende mudar o sexo para masculino
                    else
                    {
                        ut.Feminino = false;
                    }
                    

                    return 4;

                }
            }

            //Save(DATAFILE);
            return 5;
        }

        /// <summary>
        /// Esta função irá receber o número de utente que já tenha sido registado mas já não está infetado
        /// </summary>
        /// <param name="numU"></param>
        /// <returns>0-> caso a lista esteja vazia
        ///          1- caso o número de utente inserido não esteja registado
        ///          2- caso o utente tenha sido alterado ocm sucesso</returns>
        public static int EditPatient2(int numU)
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

            //Save(DATAFILE);
            //Save(DATAFILE2);
            return 1;
        }

        /// <summary>
        /// Função que faz a verificação do nif do utente, pois não podem haver nifs iguais
        /// </summary>
        /// <param name="nif"></param>
        /// <returns>
        /// 0-> Caso o nif não tenha o número de digitos correto
        /// 1-> Caso o nif já tenha sido registado por outro utente
        /// 2-> Caso o nif possa ser adicionado com sucesso</returns>
        public static int VerifyNif(int nif)
        {
            bool aux = VerifyDigits(nif);

            if (aux == false)
            {
                return 0;
            }
            else
            {
                foreach(Utente u in listaUtentes)
                {
                    if (u.Nif == nif)
                    {
                      return 1;
                    }
                }
            }
            
            return 2;
        }

        

        /// <summary>
        /// Função que, a partir da idade inserida pelo utilizador, insere todos os utentes com essa mesma idade numa lista auxiliar para que seja possivel mostrar
        /// </summary>
        /// <param name="idade"></param>
        /// <returns></returns>
        public static List<Utente> ConsultAges(int idade)
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
        public static List<Utente> ConsultRegion(string regiao)
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
        public static List<Utente> ConsultGender(bool feminino)
        {
            listaAuxiliar.Clear();

            if (feminino == true)
            {
                foreach (Utente u in listaUtentes)
                {
                    if (u.Feminino == true)
                    {
                        listaAuxiliar.Add(u);
                    }
                }
                return listaAuxiliar;
            }
            else
            {
                foreach (Utente u in listaUtentes)
                {
                    if (u.Feminino == false)
                    {
                        listaAuxiliar.Add(u);
                    }
                }
                return listaAuxiliar;
            }
        }

        /// <summary>
        /// Função que mostra a lista de utentes (onde estão inseridos todos os utentes infetados)
        /// </summary>
        /// <returns>listaUtentes</returns>
        public static List<Utente> ListInfected()
        {
            return listaUtentes;
        }

        /// <summary>
        /// Função que retorna a lista do historico de utentes (onde estão inseridos todos os utentes que já não estão infetados)
        /// </summary>
        /// <returns>listaUtentes</returns>
        public static List<Utente> ListHistoric()
        {
            return historicoUtentes;
        }


        #region Metodos_Auxiliares

        /// <summary>
        /// Função que verifica o numero de digitos do nif inserido pleo utilizador
        /// </summary>
        /// <param name="nif"></param>
        /// <returns>
        /// false-> Caso o nif não tenha o número de digitos correto
        /// true-> Caso o nif tenha os 9 digitos</returns>
        public static bool VerifyDigits(int nif)
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
        /// Função que verifica idade
        /// </summary>
        /// <param name="idade"></param>
        /// <returns>
        /// false-> Se a idade não for válida
        /// true-> Se a idade for válida</returns>
        public static bool VerifyAge(int idade)
        {
            if (idade < 0 || idade > 110)
            {
                return false;
            }
            else return true;
        }

        #endregion


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
        public static bool SaveHistoricP(string fileName)
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
        public static bool LoadHistoricP(string fileName)
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
