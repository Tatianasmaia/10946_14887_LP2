/*
 * Trabalho Prático - Linguagem de Programação II
 * 
 * Realizado por: Joana Jesus (nrº 10946) e Tatiana Maia (nrº 14887)
 * 
 * 
 * Este trabalho tem como objetivo gerir pessoas infetadas numa situação de crise de saúde pública. 
 * Deste modo, o sistema irá permitir inserir novos casos, editar e remover casos já existentes, assim como a consulta dos mesmos através dos vários tipos de informação do utente.
 * 
 */

 /*
  *VAI SER APAGADO DEPOIS DA PL ESTAR CONCLUIDA   
  */

using System;
using System.Collections.Generic;
using BO;
using BR;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {

            RegistarCaso();
            RegistarCaso();
            //ConsultaIdades();
            //ConsultaRegiao();
            //ConsultaSexo();
            //RegistarCaso();
            //RemoveUtente();

            //ListarInfetados();
            //ListarHistorico();

            Console.ReadKey();

        }

    

        /// <summary>
        /// Função que regista novo caso
        /// </summary>
        public static void RegistarCaso()
        {

            Utente u = new Utente();
            bool aux = false, aux2=false;


            //Pede os dados ao utente
            Console.WriteLine("Introduza o seu primeiro nome: ");
            string nome = Console.ReadLine();
            u.Nome = nome;

            Console.WriteLine("Introduza a sua idade: ");
            int idade = Int32.Parse(Console.ReadLine());
            while(idade < 0 || idade > 110)
            {
                Console.WriteLine("Introduza uma idade valida! : ");
                idade = Int32.Parse(Console.ReadLine());
            }
            u.Idade = idade;

            Console.WriteLine("Introduza o NIF: ");
            int nif = Int32.Parse(Console.ReadLine());

            //Verifica se o nif tem 9 digitos
            do
            {
                aux = Rules.VerificaDigitos(nif);
                if (aux == false)
                {
                    Console.WriteLine("O nif que inseriu nao tem o numero de digitos correto! Insira outra vez!");
                    nif = Int32.Parse(Console.ReadLine());
                }
            }
            while (aux == false);
            

            //Verifica se o nif já foi inserido por outro utente
            do
            {
                aux2 = Rules.VerificaNif(nif);
                if (aux2 == true)
                {
                    Console.WriteLine("Esse nif ja esta inserido! \n Insira outra vez pf!");
                    nif = Int32.Parse(Console.ReadLine());
                }
            }
            while (aux2 == true);
            

            u.Nif = nif;

            Console.WriteLine("Introduza a sua Regiao: ");
            string regiao = Console.ReadLine();
            u.Regiao = regiao;

            //Falta fazer a verificação do sexo
            Console.WriteLine("Introduza o seu sexo: ");
            string sexo = Console.ReadLine();
            //while( String.Compare(sexo,"feminino") != 0 || String.Compare(sexo, "masculino") != 0)
            ////while(sexo!= "feminino" || sexo != "masculino")
            //{
                
            //    Console.WriteLine("Introduza um sexo válido! : ");
            //    sexo = Console.ReadLine();
            //}

            u.Sexo = sexo;

            //Envia para a camada Business Rules
            aux = Rules.InsereUtente(u);


            if (aux == true)
            {
                Console.WriteLine("O utente foi adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("O utente que pretende inserir já existe!");
                Console.Clear();
                //RegistarCaso();
            }

            Rules.Save("listaUtentes");
            //Dar Clear
            Rules.Load("listaUtentes");

            Console.ReadKey();
            Console.Clear();

        }

        /// <summary>
        /// Função que remove um utente de cordo com o seu número de utente
        /// </summary>
        public static void RemoveUtente()
        {
            
            Console.WriteLine("Introduza o numero do utente que pretende remover: ");
            int num = Int32.Parse(Console.ReadLine());
            

            int aux = Rules.RemoveUtente(num);

            if (aux == 0)
            {
                Console.WriteLine("Nao existe nenhum utente inserido");
            }
            else if (aux == 1)
            {
                Console.WriteLine("O id que inseriu nao esta registado");
            }
            else if (aux == 2)
            {
                Console.WriteLine("O utente foi removido com sucesso!");

                Rules.SaveHistoricoU("historicoUtentes");
                //Dar Clear
                Rules.LoadHistoricoU("historicoUtentes");
            }
        }

        /// <summary>
        /// Função que consulta as informações de um utente através do seu nif que é introduzido pelo utilizador
        /// </summary>
        public static void PesquisaUtente()
        {
            Console.WriteLine("Introduza o nif do utente que pretende consultar: ");
            int nif = Int32.Parse(Console.ReadLine());

            Utente aux = Rules.PesquisaUtente(nif);

            Console.WriteLine("Nome: {0}  Idade: {1}  NumUtente: {2}", aux.Nome, aux.Idade, aux.NumUtente);
        }

        /// <summary>
        /// Função que volta a adicionar um utente à lista de utentes infetados através do seu número de utente
        /// Utente registado volta a estar infetado
        /// </summary>
        public static void EditaUtente2()
        {
            Console.WriteLine("Introduza o nif do utente que pretende editar: ");
            int nif = Int32.Parse(Console.ReadLine());

            int aux = Rules.EditaUtente2(nif);

            if (aux == 0)
            {
                Console.WriteLine("A lista do historico de utentes esta vazia! ");
            }
            else if (aux == 0)
            {
                Console.WriteLine("Nao existe nenhum utente com ese numero de utente! ");
            }

            else if (aux == 2)
            {
                Console.WriteLine("Utente editado com sucesso! ");
            }
        }

        /// <summary>
        /// Função que consulta utentes através da idade introduzida pelo utilizador
        /// </summary>
        public static void ConsultaIdade()
        {
            List<Utente> listaAuxiliar = new List<Utente>();

            Console.WriteLine("Introduza a idade : \n");
            int idade = Int32.Parse(Console.ReadLine());

            listaAuxiliar = Rules.ConsultaIdades(idade);

            Console.WriteLine("Utentes com a idade {0}\n", idade);
            if (listaAuxiliar.Count == 0)
            {
                Console.WriteLine("Nao existe nenhum utente com a idade {0}", idade);
            }
            else
            {
                foreach (Utente u in listaAuxiliar)
                {
                     Console.WriteLine("Nome: {0}  Regiao:{1}  Nif: {2}  Numero de Utente: {3}", u.Nome, u.Regiao, u.Nif, u.NumUtente);
                }
            }
            

        }

        /// <summary>
        /// Função que mostra os utentes da regiao inserida pelo utilizador 
        /// </summary>
        public static void ConsultaRegiao()
        {
            List<Utente> listaAuxiliar = new List<Utente>();

            Console.WriteLine("Introduz a regiao que pretende consultar : \n");
            string regiao = Console.ReadLine();

            listaAuxiliar = Rules.ConsultaRegiao(regiao);

            Console.WriteLine("Utentes de {0}:\n", regiao);
            if (listaAuxiliar.Count == 0)
            {
                Console.WriteLine("Nao existe nenhum utente pertencente a {0}", regiao);
            }
            else
            {
                foreach (Utente u in listaAuxiliar)
                {
                    Console.WriteLine("Nome: {0}  Idade:{1}  Nif: {2}  Numero de Utente: {3}", u.Nome, u.Idade, u.Nif, u.NumUtente);
                }
            }
        }

        /// <summary>
        /// Função que mostra os utentes do sexo inserido pelo utilizador
        /// </summary>
        public static void ConsultaSexo()
        {
            List<Utente> listaAuxiliar = new List<Utente>();

            Console.WriteLine("Introduz o sexo que pretende consultar : \n");
            string sexo = Console.ReadLine();

            listaAuxiliar = Rules.ConsultaSexo(sexo);

            Console.WriteLine("Utentes do sexo {0}:\n", sexo);

            if (listaAuxiliar.Count == 0)
            {
                Console.WriteLine("Nao existe nenhum utente do sexo {0}", sexo);
            }
            else
            {
                foreach (Utente u in listaAuxiliar)
                {
                    Console.WriteLine("Nome: {0}  Idade:{1}  Nif: {2}  Numero de Utente: {3}", u.Nome, u.Idade, u.Nif, u.NumUtente);
                }
            }
        }

        /// <summary>
        /// Função que lista os utentes infetados
        /// </summary>
        public static void ListarInfetados()
        {
            List<Utente> listaAuxiliar = new List<Utente>();

            listaAuxiliar = Rules.ListarInfetados();

            if (listaAuxiliar.Count == 0)
            {
                Console.WriteLine("Nao existe nenhum utente inserido!");
            }
            else
            {
                Console.WriteLine("Utentes Infetados:");
                foreach (Utente u in listaAuxiliar)
                {
                    Console.WriteLine("Nome: {0}  Idade:{1}  Nif: {2}  Numero de Utente: {3}", u.Nome, u.Idade, u.Nif, u.NumUtente);
                }
            }

        }

        /// <summary>
        /// Função que lista os utentes que já não estão infetados
        /// </summary>
        public static void ListarHistorico()
        {
            List<Utente> listaAuxiliar = new List<Utente>();

            listaAuxiliar = Rules.ListarHistorico();

            if (listaAuxiliar.Count == 0)
            {
                Console.WriteLine("Nao existe nenhum utente inserido!");
            }
            else
            {
                Console.WriteLine("Historico de Utentes:");
                foreach (Utente u in listaAuxiliar)
                {
                    Console.WriteLine("Nome: {0}  Idade:{1}  Nif: {2}  Numero de Utente: {3}", u.Nome, u.Idade, u.Nif, u.NumUtente);
                }
            }

        }



    }
}
