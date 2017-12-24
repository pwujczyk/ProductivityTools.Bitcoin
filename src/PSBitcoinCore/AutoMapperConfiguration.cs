using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSBitcoinClientCore
{
    public static class AutoMapperConfiguration
    {
        static AutoMapper.MapperConfiguration configuration;
        public static AutoMapper.MapperConfiguration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    Configure();
                }
                return configuration;
            }
        }

        public static void Configure()
        {
            configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BitcoinSimpleClientObjects.Network, NBitcoin.Network>()
                .ConvertUsing(value =>
                {
                    switch (value)
                    {
                        case BitcoinSimpleClientObjects.Network.TestNet:
                            return NBitcoin.Network.TestNet;
                        case BitcoinSimpleClientObjects.Network.Main:
                            return NBitcoin.Network.Main;
                        default:
                            throw new Exception("Missing Network type");
                    }
                });



            });

            ////maybe to delete
            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<DTO.OTask, DB.Task>()
            //    .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
            //    .ForMember(dest => dest.Html, opt => opt.MapFrom(src => src.HtmlBody))
            //    .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body));
            //});

            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<DB.Task, DTO.OTaskForPerson>()
            //         .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));
            //});


        }
    }
}