﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.DTOs.Walk;
using NZWalks.Interfaces;
using NZWalks.Models;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWalkDTO model)
        {
            var walk = _mapper.Map<Walk>(model);

            walk = await _walkRepository.CreateAsync(walk);

            if (walk == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<WalkDTO>(walk));
        }



    }
}