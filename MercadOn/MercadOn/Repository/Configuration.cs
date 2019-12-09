using Entities.Entities;
using MercadOn;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DB
{
    internal sealed class Configuration : DbMigrationsConfiguration<ContextMercadOn>
    {

        protected override void Seed(ContextMercadOn context)
        {

            //Categoria padrão

            if (context.Categorias.Count() == 0)
            {
               
                if (context.SubCategorias.Count() == 0)
                {
                    context.SubCategorias.Add(new SubcategoriaEntity()
                    {
                        CategoriaEntity = new CategoriaEntity()
                        {
                            ativo = 1,
                            nomeCategoria = "Categoria teste 1"
                        },
                     ativo = 1,
                     nomeSubcategoria = "Subcategoria teste 1"
                });

                    context.SaveChanges();
                }
            }



            if (context.Mercados.Count() == 0)
            {
                var mercadoInicial = new Entities.Entities.MercadoEntity()
                {
                    ativo = 1,
                    cnpj = 123456789,
                    nome = "Mercado Carrefour",
                    url = "~/Content/StyleLogin/images/5a0c72729642de34b6b65ce7 (1).png",
                    UsuarioEntity = new Entities.Entities.UsuarioEntity()
                    {
                        ativo = 1,
                        dataCriacao = DateTime.Now,
                        dataAlteracao = DateTime.Now,
                        email = "carrefour@mercadon.com",
                        senha = "123456"
                    }
                };

                context.Mercados.Add(mercadoInicial);
                context.SaveChanges();

                context.Produtos.Add(new ProdutoEntity()
                {
                    ativo = 1,
                    SubcategoriaEntity = context.SubCategorias.First(),
                    marcaProduto = "Salgadinhos",
                    nomeProduto = "Salgadinhos",
                    descricaoProduto = "Salgadinhos diversos, doritos, lays e ruffles.",
                    url = "~/Content/StylePaginaProdutos/imgsprodutos/5b58246ccb412-failed-products-innovations-technology-5b471e962fbd1__700.jpg"
                });

                context.Produtos.Add(new ProdutoEntity()
                {
                    ativo = 1,
                    SubcategoriaEntity = context.SubCategorias.First(),
                    marcaProduto = "Coca - Cola",
                    nomeProduto = "Coca - Cola",
                    descricaoProduto = "Refrigerante lata coca cola.",
                    url = "~/Content/StylePaginaProdutos/imgsprodutos/CCola.jpg"
                });

                context.Produtos.Add(new ProdutoEntity()
                {
                    ativo = 1,
                    SubcategoriaEntity = context.SubCategorias.First(),
                    marcaProduto = "Coca - Cola",
                    nomeProduto = "Del Valle Sucos",
                    descricaoProduto = "Sucos del valles diversos sabores.",
                    url = "~/Content/StylePaginaProdutos/imgsprodutos/Del-Valle.png"
                });

                context.Produtos.Add(new ProdutoEntity()
                {
                    ativo = 1,
                    SubcategoriaEntity = context.SubCategorias.First(),
                    marcaProduto = "Bacteria",
                    nomeProduto = "Bacteria",
                    descricaoProduto = "Sabonete anti-batericida.",
                    url = "~/Content/StylePaginaProdutos/imgsprodutos/mag-25Bacteria-t_CA0-master675.jpg"
                });

                context.Produtos.Add(new ProdutoEntity()
                {
                    ativo = 1,
                    SubcategoriaEntity = context.SubCategorias.First(),
                    marcaProduto = "Lasanha Congelada",
                    nomeProduto = "Lasanha Congelada",
                    descricaoProduto = "Lasanha congelada sadia tamanho grande.",
                    url = "~/Content/StylePaginaProdutos/imgsprodutos/PIF.jpg"
                });

                context.Produtos.Add(new ProdutoEntity()
                {
                    ativo = 1,
                    SubcategoriaEntity = context.SubCategorias.First(),
                    marcaProduto = "Heineken",
                    nomeProduto = "Heineken",
                    descricaoProduto = "Cerveja heineken long-neck 600ml",
                    url = "~/Content/StylePaginaProdutos/imgsprodutos/RNK.jpg"
                });

                context.SaveChanges();

                foreach(var produto in context.Produtos)
                {
                    context.Precos.Add(new PrecoEntity()
                    {
                        MercadoEntity = mercadoInicial,
                        ProdutoEntity = produto,
                        precoProduto = 10
                    });
                }

                context.SaveChanges();


            }

            if (context.Administradores.Count() == 0)
            {

                var usuarioMateus = new UsuarioEntity()
                {
                    ativo = 1,
                    dataAlteracao = DateTime.Now,
                    dataCriacao = DateTime.Now,
                    email = "mateus@mercadon.com",
                    senha = "123456"
                };

                var usuarioJair = new UsuarioEntity()
                {
                    ativo = 1,
                    dataAlteracao = DateTime.Now,
                    dataCriacao = DateTime.Now,
                    email = "jair@mercadon.com",
                    senha = "123456"
                };

                var usuarioFelipe = new UsuarioEntity()
                {
                    ativo = 1,
                    dataAlteracao = DateTime.Now,
                    dataCriacao = DateTime.Now,
                    email = "felipe@mercadon.com",
                    senha = "123456"
                };

                context.Usuarios.Add(usuarioMateus);
                context.Usuarios.Add(usuarioJair);
                context.Usuarios.Add(usuarioFelipe);

                var adminMateus = new AdministradorEntity()
                {
                    ativo = 1,
                    UsuarioEntity = usuarioMateus,
                    nomeAdmin = "Mateus Sanches"
                };

                var adminJair = new AdministradorEntity()
                {
                    ativo = 1,
                    UsuarioEntity = usuarioJair,
                    nomeAdmin = "Jair Brann"
                };

                var adminFelipe = new AdministradorEntity()
                {
                    ativo = 1,
                    UsuarioEntity = usuarioFelipe,
                    nomeAdmin = "Felipe Rocha"
                };

                context.Administradores.Add(adminMateus);
                context.Administradores.Add(adminJair);
                context.Administradores.Add(adminFelipe);
                context.SaveChanges();


            }
        }
    }
}