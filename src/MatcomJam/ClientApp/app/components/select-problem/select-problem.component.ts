import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { ProblemService } from '../../services/problem.service';
import { CodeService } from '../../services/code.service';
import { LanguageService } from '../../services/language.service';
import { Problem } from "../../models/problem.model";
import { Router, ActivatedRoute } from '@angular/router';
import { Language } from "../../models/language.model";
import { Code } from "../../models/code.model";
import { AuthService } from "../../services/auth.service";

@Component({
    selector: 'app-select-problem',
    templateUrl: './select-problem.component.html',
    styleUrls: ['./select-problem.component.css']
})
export class SelectProblemComponent implements OnInit {

    problem: Problem;
    userId: string;
    problemId: number;
    languageId: number;
    languages: Language[];
    code: Code = new Code();

    @ViewChild('fileInput') fileInput: ElementRef;

    constructor(private problemService: ProblemService,
        private codeService: CodeService,
        private languageService: LanguageService,
        private authService: AuthService,
        private _router: Router, private _avRoute: ActivatedRoute) {
        if (this._avRoute.snapshot.params["id"]) {
            this.problemId = this._avRoute.snapshot.params["id"];
        }
        this.userId = this.authService.currentUser.id;
    }

    ngOnInit() {
        this.problemService.getProblemById(this.problemId)
            .subscribe(p => this.problem = <Problem>(p));
        this.languageService.getLanguages()
            .subscribe(l => {
                this.languages = <Language[]>(l)
                console.log('languages', this.languages);
            });
    }

    //uploadCode() {
    //    var nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    //    this.code.UserId = this.userId;
    //    //this.code.File = nativeElement.files[0];
    //    this.code.LanguageId = this.languageId;
    //    this.code.ProblemId = this.problemId;

    //    var file = nativeElement.files[0];
    //    var formData = new FormData();
    //    console.log('file so far', file);

    //    formData.append('file', file);
    //    console.log('formdata so far', formData);
    //    this.code.file = formData;
    //    console.log('File so far', this.code.file);
        
    //    console.log('code so far', this.code);
    //    //this.codeService.upload(this.userId, this.languageId, this.problemId, file)
    //    this.codeService.upload(this.code)
    //        .subscribe(x => {
    //            console.log('code', x)
    //            //todo: navigate to submission view
    //        });
    //}

    uploadCode() {
        var nativeElement: HTMLInputElement = this.fileInput.nativeElement;
        this.codeService.upload(this.userId, this.problemId, this.languageId, nativeElement.files[0])
            .subscribe(x => {
                console.log('we did it')
            });
    }
}
