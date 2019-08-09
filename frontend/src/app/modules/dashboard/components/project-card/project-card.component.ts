import { Component, OnInit, Input } from '@angular/core';
import { ProjectDescription } from 'src/app/models/dto/project/project-description';

@Component({
  selector: 'app-project-card',
  templateUrl: './project-card.component.html',
  styleUrls: ['./project-card.component.sass']
})
export class ProjectCardComponent implements OnInit {
  DATE = new Date();
  @Input() project: ProjectDescription;

  constructor() { }

  ngOnInit() { }

  lastTimeBuild(): string {
    const daysCount = this.getDaysCountFromCurrentDate(this.project.lastBuildDate);
    if (daysCount > 365) {
      return Math.floor(daysCount / 365) + ' year ago';
    } else if (daysCount > 31) {
      return Math.floor(daysCount / 30) + ' month ago';
    } else {
      return daysCount > 1 ? daysCount + ' days ago' : daysCount === 1 ? 'yesterday' : 'today';
    }
  }

  getDaysCountFromCurrentDate(date: Date): number {
    const days = date.getUTCDate();
    const month = date.getUTCMonth();
    const year = date.getUTCFullYear();

    const currentDays = this.DATE.getUTCDate();
    const currentMonth = this.DATE.getUTCMonth();
    const currentYear = this.DATE.getUTCFullYear();

    return ((currentYear - 2019) * 365 + currentMonth * 30 + currentDays) - ((year - 2019) * 365 + month * 30 + days);
  }
}
