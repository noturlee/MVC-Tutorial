using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using HelpingHands.Models;

public class GraphController : Controller
{
	private readonly HelpinghandsContext _context;

	public GraphController(HelpinghandsContext context)
	{
		_context = context;
	}

	public async Task<IActionResult> Index()
	{
		var donations = await _context.Donations
			.Include(d => d.Project) // Include Project information
			.ToListAsync(); // Fetch all donations

		// Group by project and sum the amounts to get total donations per project
		var projectDonations = donations
			.GroupBy(d => d.Project?.ProjectName) // Group by project name
			.Select(g => new DataPoint(g.Key ?? "Unknown Project", (double)g.Sum(d => d.Amount))) // Create DataPoints
			.ToList();

		// Pass data to the view as JSON
		ViewBag.DataPoints = JsonConvert.SerializeObject(projectDonations);

		return View(); // Return the view
	}
}
