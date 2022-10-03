using System;
using Microsoft.AspNetCore.Mvc;
using PruebaGranTitan.Domain.Enums;
using PruebaGranTitan.WebAPI.DTOs;
using PruebaGranTitan.Domain;
using PruebaGranTitan.Application;

namespace PruebaGranTitan.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IBetService _betService;
        private readonly IRouletteService _rouletteService;

        public RouletteController(IRouletteService rouletteService, IBetService betService)
        {
            _rouletteService = rouletteService;
            _betService = betService;
        }

        [HttpGet]
        [Route("GetRoulette")]
        public IActionResult Get()
        {
            return Ok(_rouletteService.GetAll());
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public IActionResult RouletteOpen(int rouletteId)
        {
            try
            {
                var roulette = _rouletteService.GetByid(rouletteId);
                if (roulette == null)
                    return Ok("La id de la ruleta no existe.");

                roulette.StateId = (int)Enums.Estados.Activo;
                _rouletteService.CreateOrEdit(roulette);

                return Ok("La operación fue exitosa.");
            }
            catch (Exception ex)
            {

                return Ok("La operación fue denegada.");
            }
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public IActionResult RouletteClose(int rouletteId)
        {
            try
            {
                var roulette = _rouletteService.GetByid(rouletteId);
                if (roulette == null)
                    return Ok("La id de la ruleta no existe.");
                
                _betService.SaveResult(roulette.Id);

                return Ok("La operación fue exitosa.");
            }
            catch (Exception ex)
            {

                return Ok("La operación fue denegada.");
            }
        }

        [HttpPost]
        [Route("/[controller]/[action]")]
        public IActionResult BetRoulette(BetDto betRoulette)
        {
            try
            {
                if (!ValidateRangeNumber(betRoulette.IdNumber))
                    return Ok("El numero esta por fuera del rango.");

                if (!ValidateStateRoulette(betRoulette.IdRoulette))
                    return Ok("El estado de la ruleta esta desactivado.");

                if (!ValidateBetAmount(betRoulette.ValueBet))
                    return Ok("El valor del rango de la puesta esta por fuera del limite.");

                var bet = new Bet()
                {
                    NumberId = betRoulette.IdNumber,
                    ColorId = betRoulette.IdColor,
                    RouletteId = betRoulette.IdRoulette,
                    ValueBet = betRoulette.ValueBet
                };

                _betService.CreateOrEdit(bet);

                return Ok("La operación fue exitosa.");
            }
            catch (Exception ex)
            {

                return Ok("La operación fue denegada.");
            }
        }


        [HttpPost]
        [Route("/[controller]/[action]")]
        public IActionResult Save()
        {
            var roulette = new Roulette()
            {
                StateId = (int)Enums.Estados.Inactivo
            };
            _rouletteService.CreateOrEdit(roulette);

            return Ok(roulette.Id);
        }

        #region Validations
        private bool ValidateBetAmount(double valueBet)
        {
            if (valueBet <= 0 || valueBet > 10000)
                return false;

            return true;
        }

        private bool ValidateStateRoulette(int idRoulette)
        {
            var roulette = _rouletteService.GetByid(idRoulette);
            if (roulette == null)
                return false;
            if (roulette.StateId == (int)Enums.Estados.Inactivo)
                return false;

            return true;
        }

        private bool ValidateRangeNumber(int idNumber)
        {
            if (idNumber < 0 || idNumber > 36)
                return false;

            return true;
        }
        #endregion
    }
}
