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
    public editProblemId: any;

    constructor(private problemService: ProblemService) { }

    ngOnInit() {
        this.editProblemId = 0;
        this.loadData();
    }

    loadData() {
        this.problemService.getProblems()
            .subscribe(p => {
                this.problemList = <Problem[]>(p);
            });
    }

    delete(problemId) {
        var ans = confirm("Do you want to delete problem with Id: " + problemId);
        if (ans) {
            this.problemService.deleteProblem(problemId)
                .subscribe(p => {
                    this.loadData();
                });
        }
    }
}
