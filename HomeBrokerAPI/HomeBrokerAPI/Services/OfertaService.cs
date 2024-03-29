﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Repositories;
using HomeBrokerAPI.ViewModels;

namespace HomeBrokerAPI.Services
{
    public class OfertaService : IOfertaService
    {
        private readonly IOfertaRepository _ofertaRepository;

        public OfertaService(IOfertaRepository ofertaRepository)
        {
            this._ofertaRepository = ofertaRepository;
        }

        public async Task<List<OfertaViewModel>> listar(string ticker)
        {
            var ofertas = await _ofertaRepository.listar(ticker);

            return ofertas.Select(
                    oferta => new OfertaViewModel
                    {
                        Id = oferta.Id,
                        Tipo = oferta.Tipo,
                        IdAcao = oferta.Acao.Id,
                        Ticker = oferta.Acao.Ticker,
                        IdCorretora = oferta.Conta.Corretora.Id,
                        Corretora = oferta.Conta.Corretora.Nome,
                        Quantidade = oferta.Quantidade,
                        PrecoUnitario = oferta.PrecoUnitario,
                        DataHora = oferta.DataHora
                    }
                ).ToList();
        }

        public void Dispose()
        {
            _ofertaRepository?.Dispose();
        }
    }
}
