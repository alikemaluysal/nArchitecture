﻿using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandDto result = await Mediator!.Send(createBrandCommand);
            return Created("", result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListBrands([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() {PageRequest = pageRequest};
            BrandListModel result = await Mediator!.Send(getListBrandQuery);
            return Ok(result);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetByIdBrand([FromRoute] GetByIdBrandQuery getByIdIdBrandQuery)
        {
           BrandGetByIdDto brandGetByIdDto = await Mediator!.Send(getByIdIdBrandQuery);
           return Ok(brandGetByIdDto);
        }
    }
}
