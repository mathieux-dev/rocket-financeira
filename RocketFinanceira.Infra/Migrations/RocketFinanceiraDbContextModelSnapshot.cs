﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RocketFinanceira.Infra.Data;

#nullable disable

namespace RocketFinanceira.Infra.Migrations
{
    [DbContext(typeof(RocketFinanceiraDbContext))]
    partial class RocketFinanceiraDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RocketFinanceira.Domain.Entities.Cobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("DataCobranca")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DATA_COBRANCA");

                    b.Property<string>("IntervaloRecorrencia")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("INTERVALO_RECORRENCIA");

                    b.Property<Guid>("PAGADOR_ID")
                        .HasColumnType("uuid");

                    b.Property<bool>("Recorrente")
                        .HasColumnType("boolean")
                        .HasColumnName("RECORRENTE");

                    b.Property<string>("StatusCobranca")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("STATUS_COBRANCA");

                    b.Property<string>("TipoCobranca")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TIPO_COBRANCA");

                    b.Property<string>("TipoPagamento")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TIPO_PAGAMENTO");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("VALOR");

                    b.HasKey("Id");

                    b.HasIndex("PAGADOR_ID");

                    b.ToTable("COBRANCAS", (string)null);
                });

            modelBuilder.Entity("RocketFinanceira.Domain.Entities.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("BAIRRO");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CIDADE");

                    b.Property<string>("Complemento")
                        .HasColumnType("text")
                        .HasColumnName("COMPLEMENTO");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ESTADO");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("LOGRADOURO");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("NUMERO");

                    b.HasKey("Id");

                    b.ToTable("ENDERECOS", (string)null);
                });

            modelBuilder.Entity("RocketFinanceira.Domain.Entities.Instituicao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CNPJ");

                    b.Property<Guid>("ENDERECO_ID")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.HasIndex("ENDERECO_ID");

                    b.ToTable("INSTITUICOES", (string)null);
                });

            modelBuilder.Entity("RocketFinanceira.Domain.Entities.Notificacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("CobrancaId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DATA_ENVIO");

                    b.Property<bool>("Enviado")
                        .HasColumnType("boolean")
                        .HasColumnName("ENVIADO");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("MENSAGEM");

                    b.Property<Guid>("PagadorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TIPO");

                    b.HasKey("Id");

                    b.HasIndex("CobrancaId");

                    b.HasIndex("PagadorId");

                    b.ToTable("NOTIFICACOES", (string)null);
                });

            modelBuilder.Entity("RocketFinanceira.Domain.Entities.Pagador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DATA_NASCIMENTO");

                    b.Property<Guid>("ENDERECO_ID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("INSTITUICAO_ID")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.HasIndex("ENDERECO_ID");

                    b.HasIndex("INSTITUICAO_ID");

                    b.ToTable("PAGADORES", (string)null);
                });

            modelBuilder.Entity("RocketFinanceira.Domain.Entities.Cobranca", b =>
                {
                    b.HasOne("RocketFinanceira.Domain.Entities.Pagador", "Pagador")
                        .WithMany("Cobrancas")
                        .HasForeignKey("PAGADOR_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pagador");
                });

            modelBuilder.Entity("RocketFinanceira.Domain.Entities.Instituicao", b =>
                {
                    b.HasOne("RocketFinanceira.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("ENDERECO_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("RocketFinanceira.Domain.Entities.Contato", "Contato", b1 =>
                        {
                            b1.Property<Guid>("InstituicaoId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("EMAIL_CONTATO");

                            b1.Property<string>("Telefone")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("TELEFONE_CONTATO");

                            b1.HasKey("InstituicaoId");

                            b1.ToTable("INSTITUICOES");

                            b1.WithOwner()
                                .HasForeignKey("InstituicaoId");
                        });

                    b.Navigation("Contato")
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("RocketFinanceira.Domain.Entities.Notificacao", b =>
                {
                    b.HasOne("RocketFinanceira.Domain.Entities.Cobranca", "Cobranca")
                        .WithMany()
                        .HasForeignKey("CobrancaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RocketFinanceira.Domain.Entities.Pagador", "Pagador")
                        .WithMany()
                        .HasForeignKey("PagadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cobranca");

                    b.Navigation("Pagador");
                });

            modelBuilder.Entity("RocketFinanceira.Domain.Entities.Pagador", b =>
                {
                    b.HasOne("RocketFinanceira.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("ENDERECO_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RocketFinanceira.Domain.Entities.Instituicao", "Instituicao")
                        .WithMany()
                        .HasForeignKey("INSTITUICAO_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("RocketFinanceira.Domain.Entities.Contato", "Contato", b1 =>
                        {
                            b1.Property<Guid>("PagadorId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("EMAIL_CONTATO");

                            b1.Property<string>("Telefone")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("TELEFONE_CONTATO");

                            b1.HasKey("PagadorId");

                            b1.ToTable("PAGADORES");

                            b1.WithOwner()
                                .HasForeignKey("PagadorId");
                        });

                    b.Navigation("Contato")
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("RocketFinanceira.Domain.Entities.Pagador", b =>
                {
                    b.Navigation("Cobrancas");
                });
#pragma warning restore 612, 618
        }
    }
}
