// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RegisterComponent} from "./components/register/register.component";
import { LoginComponent } from "./components/login/login.component";
import { HomeComponent } from "./components/home/home.component";
import { CustomersComponent } from "./components/customers/customers.component";
import { ContestComponent } from "./components/contest/contest.component";
import { BlogComponent } from "./components/blog/blog.component";
import { SettingsComponent } from "./components/settings/settings.component";
import { AboutComponent } from "./components/about/about.component";
import { NotFoundComponent } from "./components/not-found/not-found.component";
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';
import { ProblemsComponent } from "./components/problems/problems.component";
import { CreateProblemComponent } from "./components/create-problem/create-problem.component";
import { SelectProblemComponent } from "./components/select-problem/select-problem.component"; 
import { CreateContestComponent } from "./components/create-contest/create-contest.component"; 
import { CreateBlogComponent } from "./components/create-blog/create-blog.component"; 


@NgModule({
    imports: [
        RouterModule.forRoot([
            { path: "", component: HomeComponent, canActivate: [AuthGuard], data: { title: "Home" } },
            { path: "login", component: LoginComponent, data: { title: "Login" } },
            {path: "login/register", component:RegisterComponent},
            { path: "customers", component: CustomersComponent, canActivate: [AuthGuard], data: { title: "Customers" } },
            { path: "problems", component: ProblemsComponent, data: { title: "Problems" } },
            { path: "problems/:id", component: SelectProblemComponent, data: { title: "SelectedProblem" } },
            { path: "insert-problem", component: CreateProblemComponent, data: { title: "CreateProblems" } },
            { path: "insert-contest", component: CreateContestComponent, data: { title: "CreateContests" } },
            { path: "insert-blog", component: CreateBlogComponent, data: { title: "CreateBlogs" } },
            { path: "problem/edit/:id", component: CreateProblemComponent, data: { title: "EditProblems" } },
            { path: "contest/edit/:id", component: CreateContestComponent, data: { title: "EditContests" } },
            { path: "blog/edit/:id", component: CreateBlogComponent, data: { title: "EditBlogss" } },
            { path: "contests", component: ContestComponent, canActivate: [AuthGuard], data: { title: "Contests" } },
            { path: "blogs", component: BlogComponent, canActivate: [AuthGuard], data: { title: "Blogs" } },
            { path: "settings", component: SettingsComponent, canActivate: [AuthGuard], data: { title: "Settings" } },
            { path: "about", component: AboutComponent, data: { title: "About Us" } },
            { path: "home", redirectTo: "/", pathMatch: "full" },
            { path: "**", component: NotFoundComponent, data: { title: "Page Not Found" } },
        ])
    ],
    exports: [
        RouterModule
    ],
    providers: [
        AuthService, AuthGuard
    ]
})
export class AppRoutingModule { }