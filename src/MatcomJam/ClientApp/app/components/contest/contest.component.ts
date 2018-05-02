import { Component, OnInit } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { ContestService } from '../../services/contest.service';
import {Contest} from '../../models/contest.model';

@Component({
    selector: 'contest',
    templateUrl: './contest.component.html',
    styleUrls: ['./contest.component.css'],
    animations: [fadeInOut],
    providers: [ContestService]
})

export class ContestComponent implements OnInit{

    contestList:Contest[];

    offset: number = 0;
    limit: number = 4;
    size: number;

    filter: any = {};

    constructor(private contestService: ContestService) { }

    ngOnInit(): void {
        this.loadData();
    }

    loadData() {
        this.getSize();
        this.findAll();
    }

    delete(id) {
        var ans = confirm("Do you want to delete problem with Id: " + id);
        if (ans) {
            this.contestService.deleContest(id)
                .subscribe(p => {
                    this.loadData();
                });
        }
    }

    getSize() {
        this.contestService.getContestCount(this.filter)
            .subscribe(c => {
                this.size = Number(c)
                console.log('size', this.size);
            });
    }

    findAll(offset: number = 1) {
        this.contestService.getContests(this.filter, offset, this.limit)
            .subscribe(b => {
                this.contestList = <Contest[]>(b);
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
