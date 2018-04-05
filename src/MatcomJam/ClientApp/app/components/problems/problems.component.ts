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
    editProblemId: any;

    offset: number = 0;
    limit: number = 4;
    size: number;

    filter: any = {};

    constructor(private problemService: ProblemService) { }

    ngOnInit() {
        console.log('asi empezo filter', this.filter.pattern)
        this.editProblemId = 0;
        this.loadData();
    }

    loadData() {
        this.getSize();
        this.findAll();
    }

    delete(problemId) {
        var ans = confirm(`Do you want to delete problem with Id: ${problemId}`);
        if (ans) {
            this.problemService.deleteProblem(problemId)
                .subscribe(p => {
                    this.loadData();
                });
        }
    }

    getSize() {
        this.problemService.getProblemCount(this.filter)
            .subscribe(c => {
                this.size = Number(c)
                console.log('problems count', this.size);
            });
    }

    findAll(offset: number = 1) {
        this.problemService.getProblems(offset, this.limit, this.filter)
            .subscribe(b => {
                this.problemList = <Problem[]>(b);
            });
    }

    onPageChange(offset) {
        this.offset = offset;
        this.findAll((offset / this.limit) + 1);
    }

    onSearchChanged() {
        this.loadData();
    }
}
