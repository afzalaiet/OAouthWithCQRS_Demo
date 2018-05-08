﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeremonyBazar.CQRS.Query.Contract
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        TResult Process(TQuery query);
    }

}
