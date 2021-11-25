using System.Collections.Generic;
using System;
using System.Linq;
using server.Data;
using server.Models;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{

    [ApiController]
    [Route("server/formaPagamento")]
    public class FormaPagamentoController
    {
        private readonly DataContext _context;

        public FormaPagamentoController(DataContext context) => _context = context;

        [HttpPost]
        [Route("create")]
        public FormaPagamento Create(FormaPagamento formaPagamento)
        {
            _context.FormasPagamento.Add(formaPagamento);
            _context.SaveChanges();
            return formaPagamento;
        }

        [HttpGet]
        [Route("list")]
        public List<FormaPagamento> List() => _context.FormasPagamento.ToList();

        [HttpGet]
        [Route("findById/{id?}")]
        public FormaPagamento GetById(int id) => _context.FormasPagamento.Find(id);

        [HttpPut]
        [Route("update")]
        public FormaPagamento Update([FromBody] FormaPagamento formaPagamento)
        {
            _context.FormasPagamento.Update(formaPagamento);
            _context.SaveChanges();
            return formaPagamento;
        }

        [HttpDelete]
        [Route("delete/{id?}")]
        public FormaPagamento Delete(int id)
        {
            FormaPagamento formaPagamento = GetById(id);
            _context.FormasPagamento.Remove(formaPagamento);
            _context.SaveChanges();
            return formaPagamento;
        }
    }
}