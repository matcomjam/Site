// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

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

    constructor(private contestService: ContestService) { }

    ngOnInit(): void {
        this.loadData();
    }

    loadData() {
        this.getSize();
        this.findAll(this.limit);
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
        this.contestService.getContestCount()
            .subscribe(c => {
                this.size = Number(c)
                console.log('size', this.size);
            });
    }

    findAll(limit: number, offset: number = 1) {
        this.contestService.getContests(offset, limit)
            .subscribe(b => {
                this.contestList = <Contest[]>(b);
            });
    }

    onPageChange(offset) {
        this.offset = offset;
        this.findAll(this.limit, (offset / this.limit) + 1);
    }
}
