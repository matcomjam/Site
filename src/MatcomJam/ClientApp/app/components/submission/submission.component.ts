import { Component, OnInit } from '@angular/core';
import { CodeService } from "../../services/code.service";
import { Code } from "../../models/code.model";

@Component({
    selector: 'app-submission',
    templateUrl: './submission.component.html',
    styleUrls: ['./submission.component.css']
})
export class SubmissionComponent implements OnInit {

    codes: Code[];
    constructor(private codeService: CodeService) { }

    ngOnInit() {
        this.codeService.getCodes()
            .subscribe(c => this.codes = <Code[]>(c));
    }

}
