﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.Repos;

namespace Web.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ReservaCanchaContext _context;

        public ReservaController(ReservaCanchaContext context)
        {
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var reservaCanchaContext = _context.Reserva.Include(r => r.Cancha).Include(r => r.Estado).Include(r => r.Persona);
            return View(await reservaCanchaContext.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Cancha)
                .Include(r => r.Estado)
                .Include(r => r.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            ViewBag.idCancha = new SelectList(_context.Cancha, "Id", "Nombre");
            //ViewBag.idPersona = _context.Persona.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = $"{p.Nombre} {p.Apellido}" });
            ViewBag.idPersona = new SelectList(_context.Persona, "Id", "NombreCompleto");
            ViewBag.idEstado = new SelectList(_context.Estado, "Id", "Nombre");

            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fecha,HoraInicio,HoraFin,idCancha,idEstado, idPersona")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {

                reserva.Cancha = await _context.Cancha.FindAsync(reserva.idCancha);
                reserva.Persona = await _context.Persona.FindAsync(reserva.idPersona);
                reserva.Estado = await _context.Estado.FindAsync(reserva.idEstado);


                _context.Reserva.Add(reserva);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }


            ViewBag.idCancha = new SelectList(_context.Cancha, "Id", "Nombre", reserva.idCancha);
            ViewBag.idPersona = new SelectList(_context.Persona, "Id", "NombreCompleto", reserva.idPersona);
            ViewBag.idEstado = new SelectList(_context.Estado, "Id", "Nombre", reserva.idEstado);

            return View(reserva);
        }

    // GET: Reserva/Edit/5
    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["idCancha"] = new SelectList(_context.Cancha, "Id", "Id", reserva.idCancha);
            ViewData["idEstado"] = new SelectList(_context.Estado, "Id", "Id", reserva.idEstado);
            ViewData["idPersona"] = new SelectList(_context.Persona, "Id", "Id", reserva.idPersona);
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,HoraInicio,HoraFin,idCancha,idPersona,idEstado")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCancha"] = new SelectList(_context.Cancha, "Id", "Id", reserva.idCancha);
            ViewData["idEstado"] = new SelectList(_context.Estado, "Id", "Id", reserva.idEstado);
            ViewData["idPersona"] = new SelectList(_context.Persona, "Id", "Id", reserva.idPersona);
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Cancha)
                .Include(r => r.Estado)
                .Include(r => r.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reserva == null)
            {
                return Problem("Entity set 'ReservaCanchaContext.Reserva'  is null.");
            }
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
          return (_context.Reserva?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
