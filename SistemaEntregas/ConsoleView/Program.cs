﻿using Controllers;
using Modelos;
using System;

namespace ConsoleView
{
    class Program
    {
        enum OpcoesMenuPrincipal

        {
            CadastrarCliente = 1,
            PesquisarCliente = 2,
            EditarCliente = 3,
            ExcluirCliente = 4,
            ListarClientes = 5,
            LimparTela = 6,
            Sair = 7
            //testando github
        }

        private static OpcoesMenuPrincipal Menu()
        {
            Console.WriteLine("Escolha sua opcao");
            Console.WriteLine("");

            Console.WriteLine(" - Clientes - ");
            Console.WriteLine("1 - Cadastrar Novo");
            Console.WriteLine("2 - Pesquisar Cliente");
            Console.WriteLine("3 - Editar Cliente");
            Console.WriteLine("4 - Excluir Cliente");
            Console.WriteLine("5 - Listar Clientes");

            Console.WriteLine(" - Geral -");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("7 - Sair");

            //return Convert.ToInt32(Console.ReadLine());
            string opcao = Console.ReadLine();
            return (OpcoesMenuPrincipal) int.Parse(opcao);
        }
        static void Main(string[] args)
        {
            OpcoesMenuPrincipal opcaoDigitada = 
                OpcoesMenuPrincipal.Sair;

            do
            {
                opcaoDigitada = Menu();

                switch (opcaoDigitada)
                {
                    case OpcoesMenuPrincipal.CadastrarCliente:
                        Cliente c = CadastrarCliente();

                        ClienteController cc = new ClienteController();
                        cc.SalvarCliente(c);
                        
                        ExibirDadosCliente(c);
                        break;
                    case OpcoesMenuPrincipal.PesquisarCliente:
                        PesquisarCliente();
                        break;
                    case OpcoesMenuPrincipal.EditarCliente:
                        break;
                    case OpcoesMenuPrincipal.ExcluirCliente:
                        ExcluirCliente();
                        break;
                    case OpcoesMenuPrincipal.ListarClientes:
                        ListarClientes();
                        break;
                    case OpcoesMenuPrincipal.LimparTela:
                        LimparTela();
                        break;
                    case OpcoesMenuPrincipal.Sair:
                        break;
                    default:
                        break;
                }
               
            } while (opcaoDigitada != OpcoesMenuPrincipal.Sair);
            
        }

        private static void LimparTela()
        {
            Console.Clear();
        }

        private static void ListarClientes()
        {
            ClienteController cc = new ClienteController();
            foreach (var cliente in cc.ListarClientes())
            {
                ExibirDadosCliente(cliente);
            }
        }

        private static void ExcluirCliente()
        {
            Console.WriteLine("Digite o id do cliente que deseja excluir: ");
            int idCliente = int.Parse(Console.ReadLine());

            ClienteController cc = new ClienteController();
            cc.ExcluirCliente(idCliente);
        }

        // Metodos Cliente
        private static Cliente CadastrarCliente()
        {
            Cliente cliente = new Cliente();

            Console.Write("Digite o nome: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Digite o cpf: ");
            cliente.Cpf = Console.ReadLine();

            // ... Endereco
            Endereco endereco = new Endereco();

            Console.Write("Digite o nome da rua: ");
            endereco.Rua = Console.ReadLine();

            Console.Write("Digite o numero: ");
            endereco.Numero = int.Parse(Console.ReadLine());

            Console.Write("Digite o complemento: ");
            endereco.Complemento = Console.ReadLine();

            cliente._Endereco = endereco;

            return cliente;
        }

        private static void PesquisarCliente()
        {
            Console.WriteLine("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            ClienteController cc = new ClienteController();
            Cliente cliente = cc.PesquisarPorNome(nomeCliente);

            if (cliente != null)
                ExibirDadosCliente(cliente);
            else
                Console.WriteLine(" * Erro: Cliente não encontrado");
        }

        private static void ExibirDadosCliente(Cliente cliente)
        {
            Console.WriteLine();
            Console.WriteLine("--- DADOS CLIENTE --- ");
            Console.WriteLine("Id.....: " + cliente.PessoaID);
            Console.WriteLine("Nome...: " + cliente.Nome);
            Console.WriteLine("Cpf....: " + cliente.Cpf);

            Console.WriteLine("- Endereco -");
            Console.WriteLine("Rua....: " + cliente._Endereco.Rua);
            Console.WriteLine("Num....: " + cliente._Endereco.Numero);
            Console.WriteLine("Compl..: " + cliente._Endereco.Complemento);
            Console.WriteLine("--------------------- ");
        }
    }
}
