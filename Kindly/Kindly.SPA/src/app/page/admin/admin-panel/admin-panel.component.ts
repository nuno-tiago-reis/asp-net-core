// components
import { Component, OnInit } from '@angular/core';

@Component
({
	selector: 'app-admin-panel',
	templateUrl: './admin-panel.component.html',
	styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit
{
	/**
	 * Creates an instance of the home component.
	 */
	public constructor ()
	{
		// Nothing to do here.
	}

	/**
	 * A lifecycle hook that is called after Angular has initialized all data-bound properties of a directive.
	 */
	public ngOnInit (): void
	{
		// Nothing to do here.
	}
}