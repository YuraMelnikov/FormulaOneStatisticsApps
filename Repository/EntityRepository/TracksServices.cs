﻿using AutoMapper;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repository.DTO;
using Repository.IEntityRepository;

namespace Repository.EntityRepository
{
    public class TracksServices :  ITracksServices
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;

        public TracksServices(RepositoryContext repositoryContext, IMapper mapper)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TracksDto>> GetTracksList()
        {
            var tracksList = await _repositoryContext.Tracks
                .AsNoTracking()
                .Include(a => a.Image)
                .OrderBy(a => a.Name)
                .ToArrayAsync();
            return _mapper.Map<IEnumerable<TracksDto>>(tracksList);
        }
    }
}