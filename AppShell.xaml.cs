﻿using PrawoJazdy.Pages;

namespace PrawoJazdy;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(QuizPage), typeof(QuizPage));
	}
}
