namespace VoiceSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using VoiceSystem.Data.Common;
    using VoiceSystem.Data.Models;

    public class IdeasService : BaseDataService<Idea>, IIdeasService
    {
        public IdeasService(IDbRepository<Idea> dataSet) 
            : base(dataSet)
        {
        }

    }
}
