import { Component, OnInit } from '@angular/core';
import { ProblemService } from '../../services/problem.service';
import { Problem } from "../../models/problem.model";

@Component({
    selector: 'app-problems',
    templateUrl: './problems.component.html',
    styleUrls: ['./problems.component.css'],
    providers: [ProblemService]
})
export class ProblemsComponent implements OnInit {
    problemList: Problem[];

    constructor(private problemService: ProblemService) { }

    ngOnInit() {
        this.problemService.getProblems()
            .subscribe(p => {
                this.problemList = <Problem[]>(p);
                console.log('problem', this.problemList);
            });
    }
}
