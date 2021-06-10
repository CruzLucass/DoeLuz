using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace DoeLuz.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context =
                app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Admins.Any())
            {
                context.Admins.AddRange(
                    new Admin
                    {
                        Nome = "Paulo Soares",
                        Senha = "1234",
                        Cpf = "130.273.866-62",
                        Email = "paulodoeluz@gmail.com",
                        Endereco = "Rua Joao da cunha Bastos, 500",
                        NomeOng = "Caminho da Luz"
                    });
                context.SaveChanges();
                context.Beneficiarios.AddRange(
                    new Beneficiario
                    {
                        Nome = "João Paulo",
                        Senha = "12345",
                        Email = "jp123@gmail.com",
                        Endereco = "Rua da Virtude, 59",
                        Preferencia = "Comida",
                        DataNascimento = "12/05/1995",
                        Historia = "Desde o inicio da pandemia perdi o emprego e estou passando por dificuldades.",
                        Status = null
                    },
                    new Beneficiario
                    {
                        Nome = "Lucas Dias",
                        Senha = "12345",
                        Email = "lucasdias@gmail.com",
                        Endereco = "Rua Nossa Senhora Aparecida, 154",
                        Preferencia = "Roupas",
                        DataNascimento = "23/06/1981",
                        Historia = "Tenho 5 filhos e recebo muito pouco no meu emprego",
                        Status = null
                    },
                    new Beneficiario
                    {
                        Nome = "Julia Maciel",
                        Senha = "12345",
                        Email = "juliam@gmail.com",
                        Endereco = "Rua Pedro de Carvalho, 20",
                        Preferencia = "Higiene Pessoal",
                        DataNascimento = "01/02/1989",
                        Historia = "Desde o inicio da pandemia perdi o emprego e estou passando por dificuldades.",
                        Status = null
                    },
                    new Beneficiario
                    {
                        Nome = "Carlos Eduardo",
                        Senha = "123456",
                        Email = "carlosedu@gmail.com",
                        Endereco = "Rua da Saudade, 79",
                        Preferencia = "Roupas",
                        DataNascimento = "30/07/1991",
                        Historia = "Desde o inicio da pandemia perdi o emprego e estou passando por dificuldades.",
                        Status = "disponivel"
                    });
                context.SaveChanges();
                context.Doadores.AddRange(
                new Doador
                    {
                        Nome = "Ricardo Lemos",
                        Senha = "123",
                        Email = "ricardo@gmail.com",
                        Endereco = "Rua da Liberdade, 105"
                    },
                new Doador
                     {
                         Nome = "Ana Clara Alves",
                         Senha = "123",
                         Email = "anaclara@gmail.com",
                         Endereco = "Rua São Paulo, 800",
                         Telefone = "3564578329"
                     },
                new Doador
                {
                    Nome = "Julio Cesar Pereira",
                    Senha = "123",
                    Email = "juliopracisporte@gmail.com",
                    Endereco = "Rua Dr Carlos, 259"
                });
                context.SaveChanges();
                context.Doacoes.AddRange(
                    new Doacao
                     {
                         AdminID = 1,
                         DoadorID = 3,
                         BeneficiarioID = 2,
                         DataEntrega = "10/06/2021",
                         Confirma = "confirmado",
                         TipoDoacao = "direta",
                         Item = "Roupas",
                         Mensagem = "desejo agendar a data pra entrega."
                     },
                    new Doacao
                    {
                        AdminID = 1,
                        DoadorID = 2,
                        BeneficiarioID = 3,
                        DataEntrega = "29/06/2021",
                        Confirma = "confirmado",
                        TipoDoacao = "direta",
                        Item = "Higiene Pessoal",
                        Mensagem = "desejo agendar a data pra entrega."
                    },
                    new Doacao
                    {
                        AdminID = 1,
                        DoadorID = 1,
                        BeneficiarioID = 1,
                        DataEntrega = "25/05/2021",
                        Confirma = "confirmado",
                        TipoDoacao = "direta",
                        Item = "Cesta básica",
                        Mensagem = "desejo agendar a data pra entrega."
                    });
                context.SaveChanges();
            }
        }
    }
}
