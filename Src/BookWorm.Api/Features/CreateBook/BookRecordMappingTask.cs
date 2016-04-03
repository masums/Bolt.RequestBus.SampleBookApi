using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookWorm.Api.Features.Shared.Dto;
using BookWorm.Api.Infrastructure;
using BookWorm.Api.Infrastructure.Mappers;

namespace BookWorm.Api.Features.CreateBook
{
    public class BookRecordMappingTask : IStartUpTask
    {
        public void Run()
        {
            AutoMapper.Mapper.CreateMap<CreateBookRequest, BookRecord>()
                .ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}