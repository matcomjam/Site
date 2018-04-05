import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { ProblemService } from '../../services/problem.service';
import { CodeService } from '../../services/code.service';
import { Problem } from "../../models/problem.model";
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-select-problem',
    templateUrl: './select-problem.component.html',
    styleUrls: ['./select-problem.component.css']
})
export class SelectProblemComponent implements OnInit {

    problem: Problem;
    problemId: number;

    @ViewChild('fileInput') fileInput: ElementRef;

    constructor(private problemService: ProblemService,
        private codeService: CodeService,
        private _router: Router, private _avRoute: ActivatedRoute) {
        if (this._avRoute.snapshot.params["id"]) {
            this.problemId = this._avRoute.snapshot.params["id"];
        }
    }

    ngOnInit() {
        this.problemService.getProblemById(this.problemId)
            .subscribe(p => this.problem = <Problem>(p));
    }

    uploadCode() {
        var nativeElement: HTMLInputElement = this.fileInput.nativeElement;

        this.codeService.upload(this.problemId, nativeElement.files[0])
            .subscribe(x => console.log('code', x));
    }
}
