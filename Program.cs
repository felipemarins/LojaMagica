using System;
using System.Collections.Generic;

namespace LojaMagica
{
    class Program
    {
        static void Main(string[] args)
        {
            Loja loja = new Loja();
            bool sair = false;
            do
            {
                Menu menuInicial = new Menu();
                menuInicial.IniciarMenuPadrao("Selecione se você é um cliente ou um administrador.\n",
                    new List<string> { "Sou um cliente", "Sou um adminstrador", "Sair" });
                Console.Clear();
                if (menuInicial.Selecao == 0) { sair = true; }
                else if (menuInicial.Selecao == 1)
                {
                    Console.WriteLine("Comprando");
                }
                else if (menuInicial.Selecao == 2)
                {
                    do
                    {
                        Menu menuAdministrador = new Menu();
                        menuAdministrador.IniciarMenuPadrao("Bem-vindo, administrador!\n",
                            new List<string> { "Adicionar um novo item ao catálogo", "Salvar estoque", "Carregar estoque",
                            "Adicionar unidades a um item", "Listar items no estoque", "Ver detalhes de um item", "Voltar" });
                        if (menuAdministrador.Selecao == 0) { sair = true; }
                        else if (menuAdministrador.Selecao == 1) { loja.AdicionarItem(); }
                        else if (menuAdministrador.Selecao == 2) { loja.SalvarEstoque(); }
                        else if (menuAdministrador.Selecao == 3) { loja.CarregarEstoque(); }
                        else if (menuAdministrador.Selecao == 4)
                        {
                            Console.Clear();
                            Console.Write("Nome do item: ");
                            string nomeDoItem = Console.ReadLine();
                            loja.AdicionarUnidadesItem(nomeDoItem);
                        }
                        else if (menuAdministrador.Selecao == 5) { loja.ImprimirEstoque(); }
                        else if (menuAdministrador.Selecao == 6)
                        {
                            Console.Clear();
                            Console.Write("Nome do item: ");
                            string nomeDoItem = Console.ReadLine();
                            loja.ImprimirDetalhesItem(nomeDoItem);
                        }
                    } while (sair != true);
                    sair = false;
                }
            } while (sair != true);
        }
    }
}
