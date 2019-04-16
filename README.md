# Coded Mile - Milestone Planner Project

<p>Authors: Ross Taggart, Aidan Marshall, Katie King and Mark Riley</p>
<p>You can find our group document and their relevent appendixes in the Docs folder</p>

<span><strong>Last Updated - 16/04/2019</strong></span>

<h2>Overview</h2>

<p>This repository contains the code of the Coded Mile Milestone Planner project for Web Platform Development 2. Master is the most
up to date branch and any clone commands should be from this branch. This repository alos contains the team and group reports created
during this project located in the Docs folder. The below sections provide more details on the contents of this repository.</p>

<h3>Technologies Used</h3>

<p>Below is a list of the technology used in this repository</p>

<ul>
  <li>ASP.NET Core 2.0</li>
  <li>Visual Studio 2017 Community</li>
  <li>Entity Framework 2.2.4</li>
</ul>

<h3>Installation</h3>

<p>This section defines how to run the application once it has been cloned from this repository. The cloned project will default
to the master branch</p>

<h4>Step 1: Open Solution</h4>

<p>This step involves ensuring that the CodedMilePlanner.sln is open. If done correctly the solution explorer should appear like this</p>

<img src="https://github.com/rtaggart16/MilestonePlanner/blob/master/img/sol_exp.PNG" />

<h4>Step 2: Check for Migrations</h4>

<p>This step involves ensuring that the solution contains migrations with which the database can be created from</p>

<img src="https://github.com/rtaggart16/MilestonePlanner/blob/master/img/migrations.PNG" />

<h4>Step 3: Check the name of the database in appsettings.json</h4>

<p>This step involves checking the name of the database in the appsettings.json. This database can be found in SQL Server Object Explorer when migrations are run</p>

<img src="https://github.com/rtaggart16/MilestonePlanner/blob/master/img/appsettings.PNG" />

<h4>Step 4: Run "Update-Database"</h4>

<p>This step involves running the update-database command to apply the migrations to the specified database</p>

<img src="https://github.com/rtaggart16/MilestonePlanner/blob/master/img/pcg_man.PNG" />
