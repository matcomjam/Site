import { Component, OnInit } from '@angular/core';
import { ProblemService } from '../../services/problem.service';
import { Problem } from "../../models/problem.model";
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
    selector: 'app-create-problem',
    templateUrl: './create-problem.component.html',
    styleUrls: ['./create-problem.component.css'],
    providers: [ProblemService]
})
export class CreateProblemComponent implements OnInit {
    problemForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;

    constructor(private _formB: FormBuilder, private problemService: ProblemService,
        private _router: Router, private _avRoute: ActivatedRoute) {
        //_avRoute.params.subscribe(p => {
        //    this.id = +p["id"];
        //});
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.problemForm = this._formB.group({
            id: 0,
            title: ['', [Validators.required]],
            tag: ['', [Validators.required]],
            description: ['', [Validators.required]],
            timeLimit: 0,
            memoryLimit: 0,
            maximumMessages: 0,
            numberOfNodes: 0,
            sizeOfMessages: 0
        });
    }

    ngOnInit() {
        if (this.id > 0) {
            this.title = "Edit";
            this.problemService.getProblemById(this.id)
                .subscribe((p: Problem) => {
                    this.problemForm.setValue(p);
                });
            error => this.errorMessage = error;
        }
    }

    //onSubmit(form: NgForm) {
    //    this.problemService.postProblem(form.value)
    //        .subscribe(res => {
    //            this._router.navigate(['/problems']);
    //        });
    //}

    save() {
        if (!this.problemForm.valid) {
            return;
        }
        if (this.title == "Create") {
            this.problemService.saveProblem(this.problemForm.value)
                .subscribe(p => {
                    this._router.navigate(['/problems']);
                },
                error => this.errorMessage = error);
        }
        else if (this.title == "Edit") {
            this.problemService.updateProblem(this.problemForm.value)
                .subscribe(p => {
                    console.log('por que no estas yendo pa esa direccion');
                    this._router.navigate(['/problems']);
                })
            //error => this.errorMessage = error);
        }
    }

    cancel() {
        this._router.navigate(['/problems']);
    }

    problemTitle() { return this.problemForm.get('title'); }
    problemTag() { return this.problemForm.get('tag'); }
    problemDescription() { return this.problemForm.get('description'); }
}
