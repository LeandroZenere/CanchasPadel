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
            var reservaCanchaContext = _context.Reserva.Include(r => r.Cancha).Include(r => r.Estado);
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
            ViewData["idCancha"] = new SelectList(_context.Cancha, "Id", "Id");
            ViewData["idEstado"] = new SelectList(_context.Estado, "Id", "Id");
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,HoraInicio,HoraFin,idCancha,idEstado, PersonaNombre, PersonaApellido")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                // Save the reservation to the database
                _context.Add(reserva);
                await _context.SaveChangesAsync();

                // Update the cancha's state
                Cancha cancha = _context.Cancha.Find(reserva.idCancha);
                cancha.Estado = reserva.idEstado;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            ViewData["idCancha"] = new SelectList(_context.Cancha, "Id", "Nombre", reserva.idCancha);
            ViewData["idEstado"] = new SelectList(_context.Estado, "Id", "Nombre", reserva.idEstado);
            return View(reserva);

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
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,HoraInicio,HoraFin,idCancha,idEstado")] Reserva reserva)
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
