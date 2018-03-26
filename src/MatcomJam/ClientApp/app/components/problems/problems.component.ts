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

    offset: number = 0;
    limit: number = 4;
    size: number;

    constructor(private problemService: ProblemService) { }

    ngOnInit() {
        this.editProblemId = 0;
        this.loadData();
    }

    loadData() {
        this.getSize();
        this.findAll(this.limit);
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

    getSize() {
        this.problemService.getProblemCount()
            .subscribe(c => {
                this.size = Number(c)
                console.log('problems count', this.size);
            });
    }

    findAll(limit: number, offset: number = 1) {
        this.problemService.getProblems(offset, limit)
            .subscribe(b => {
                this.problemList = <Problem[]>(b);
            });
    }

    onPageChange(offset) {
        this.offset = offset;
        this.findAll(this.limit, (offset / this.limit) + 1);
    }
}
