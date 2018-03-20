import { Component, OnInit } from '@angular/core';
import { ContestService } from "../../services/contest.service";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Contest } from "../../models/contest.model";

@Component({
  selector: 'app-create-contest',
  templateUrl: './create-contest.component.html',
  styleUrls: ['./create-contest.component.css'],
  providers: [ContestService]
})
export class CreateContestComponent implements OnInit {

    contestForm: FormGroup;
    title: string = "Create";
    contestId: number;
    errorMessage: any;

    constructor(private contestService: ContestService,
        private _formB: FormBuilder,
        private _router: Router,
        private _avRoute: ActivatedRoute) {

        if (this._avRoute.snapshot.params["id"]) {
            this.contestId = this._avRoute.snapshot.params["id"];
        }

        this.contestForm = this._formB.group({
            contestId: 0,
            title: ['', [Validators.required]],
            description: ['', [Validators.required]],
            duration: 0
        });
    }

    ngOnInit() {
        if (this.contestId > 0) {
            this.title = "Edit";
            this.contestService.getContestById(this.contestId)
                .subscribe((c: Contest) => {
                    this.contestForm.setValue(c);
                });
            error => this.errorMessage = error;
        }
    }
    save() {
        if (!this.contestForm.valid) {
            return;
        }
        if (this.title == "Create") {
            this.contestService.saveContest(this.contestForm.value)
                .subscribe(p => {
                        this._router.navigate(['/contests']);
                    },
                    error => this.errorMessage = error);
        }
        else if (this.title == "Edit") {
            this.contestService.updateContest(this.contestForm.value)
                .subscribe(p => {
                    console.log('por que no estas yendo pa esa direccion');
                    this._router.navigate(['/contests']);
                })
            //error => this.errorMessage = error);
        }
    }

    cancel() {
        this._router.navigate(['/contests']);
    }
}
