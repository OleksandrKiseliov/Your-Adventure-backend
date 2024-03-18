using CurdOperationWithDapperNetCoreMVC_Demo.Models;
using CurdOperationWithDapperNetCoreMVC_Demo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CurdOperationWithDapperNetCoreMVC_Demo.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPerson personRepository;

        public PersonsController(IPerson personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<IActionResult> Index()
        {
            var persons = await personRepository.Get();
            return View(persons);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var person = await personRepository.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                await personRepository.Add(model);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var person = await personRepository.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PersonModel model)
        {
            if (id != model.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await personRepository.Update(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var person = await personRepository.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            var person = await personRepository.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            await personRepository.Remove(person);
            return RedirectToAction(nameof(Index));
        }
    }
}
