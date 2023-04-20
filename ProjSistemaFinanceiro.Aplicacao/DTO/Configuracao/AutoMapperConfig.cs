using AutoMapper;
using ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.Banco;
using ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.Categoria;
using ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.MetodoPagamento;
using ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.NomeCartao;
using ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.TipoConta;
using ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.TipoControle;
using ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.Transacao;
using ProjSistemaFinanceiro.Entidade.Entidades;

namespace ProjSistemaFinanceiro.Aplicacao.DTO.Configuracao
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<BancoAddDTO, BancoEntity>();
            CreateMap<BancoUpdDTO, BancoEntity>();
            CreateMap<BancoViewDTO, BancoEntity>().ReverseMap()
                .ForMember(cvm => cvm.DataAlteracao, options => options.MapFrom(te => te.DataAlteracao.ToString("dd/MM/yyyy")))
                .ForMember(cvm => cvm.DataCriacao, options => options.MapFrom(te => te.DataCriacao.ToString("dd/MM/yyyy")));

            CreateMap<CategoriaAddDTO, CategoriaEntity>();
            CreateMap<CategoriaUpdDTO, CategoriaEntity>();
            CreateMap<CategoriaViewDTO, CategoriaEntity>().ReverseMap()
                .ForMember(cvm => cvm.DataAlteracao, options => options.MapFrom(te => te.DataAlteracao.ToString("dd/MM/yyyy")))
                .ForMember(cvm => cvm.DataCriacao, options => options.MapFrom(te => te.DataCriacao.ToString("dd/MM/yyyy")));

            CreateMap<MetodoPagamentoAddDTO, MetodoPagamentoEntity>();
            CreateMap<MetodoPagamentoUpdDTO, MetodoPagamentoEntity>();
            CreateMap<MetodoPagamentoViewDTO, MetodoPagamentoEntity>().ReverseMap()
                .ForMember(cvm => cvm.DataAlteracao, options => options.MapFrom(te => te.DataAlteracao.ToString("dd/MM/yyyy")))
                .ForMember(cvm => cvm.DataCriacao, options => options.MapFrom(te => te.DataCriacao.ToString("dd/MM/yyyy")));

            CreateMap<NomeCartaoAddDTO, NomeCartaoEntity>();
            CreateMap<NomeCartaoUpdDTO, NomeCartaoEntity>();
            CreateMap<NomeCartaoViewDTO, NomeCartaoEntity>().ReverseMap()
                .ForMember(cvm => cvm.DataAlteracao, options => options.MapFrom(te => te.DataAlteracao.ToString("dd/MM/yyyy")))
                .ForMember(cvm => cvm.DataCriacao, options => options.MapFrom(te => te.DataCriacao.ToString("dd/MM/yyyy")));

            CreateMap<TipoContaAddDTO, TipoContaEntity>();
            CreateMap<TipoContaUpdDTO, CategoriaEntity>();
            CreateMap<TipoContaViewDTO, CategoriaEntity>().ReverseMap()
                .ForMember(cvm => cvm.DataAlteracao, options => options.MapFrom(te => te.DataAlteracao.ToString("dd/MM/yyyy")))
                .ForMember(cvm => cvm.DataCriacao, options => options.MapFrom(te => te.DataCriacao.ToString("dd/MM/yyyy")));

            CreateMap<TipoControleAddDTO, TipoControleEntity>();
            CreateMap<TipoControleUpdDTO, TipoControleEntity>();
            CreateMap<TipoControleViewDTO, TipoControleEntity>().ReverseMap()
                .ForMember(cvm => cvm.DataAlteracao, options => options.MapFrom(te => te.DataAlteracao.ToString("dd/MM/yyyy")))
                .ForMember(cvm => cvm.DataCriacao, options => options.MapFrom(te => te.DataCriacao.ToString("dd/MM/yyyy")));

            CreateMap<TransacaoAddDTO, TransacaoEntity>();
            CreateMap<TransacaoUpdDTO, TransacaoEntity>();
            CreateMap<TransacaoViewDTO, TransacaoEntity>().ReverseMap()
                .ForMember(tvm => tvm.Categoria, options => options.MapFrom(te => te.Categoria!.Nome.ToString()))
                .ForMember(tvm => tvm.TipoConta, options => options.MapFrom(te => te.TipoConta!.Nome.ToString()))
                .ForMember(tvm => tvm.TipoControle, options => options.MapFrom(te => te.TipoControle!.Nome.ToString()))
                .ForMember(tvm => tvm.MetodoPagamento, options => options.MapFrom(te => te.MetodoPagamento!.Nome.ToString()))
                .ForMember(tvm => tvm.NomeCartao, options => options.MapFrom(te => te.NomeCartao!.Nome.ToString()))
                .ForMember(tvm => tvm.Banco, options => options.MapFrom(te => te.Banco!.Nome.ToString()))
                .ForMember(tvm => tvm.DataCompra, options => options.MapFrom(te => te.DataCompra.ToString("dd/MM/yyyy")))
                .ForMember(tvm => tvm.DataPagamento, options => options.MapFrom(te => te.DataPagamento.ToString("dd/MM/yyyy")))
                .ForMember(tvm => tvm.DataAlteracao, options => options.MapFrom(te => te.DataAlteracao.ToString("dd/MM/yyyy")))
                .ForMember(tvm => tvm.DataCriacao, options => options.MapFrom(te => te.DataCriacao.ToString("dd/MM/yyyy")));
        }
    }
}
