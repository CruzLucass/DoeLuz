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
                        DataEntrega = "25/05/2021",
                        Historia = "Desde o inicio da pandemia perdi o emprego e estou passando por dificuldades.",
                        Status = "disponivel"
                    },
                    new Beneficiario
                    {
                        Nome = "Carlos Eduardo",
                        Senha = "123456",
                        Email = "carlosedu@gmail.com",
                        Endereco = "Rua da Saudade, 79",
                        Preferencia = "Roupas",
                        DataEntrega = "25/05/2021",
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
                    });
                context.SaveChanges();
                context.Doacoes.AddRange(
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
