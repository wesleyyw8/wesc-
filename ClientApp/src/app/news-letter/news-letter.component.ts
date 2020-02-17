import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DataService } from '../data/data.service';
import { NewsLetterForm } from '../data/news-letter-form';

@Component({
  selector: 'app-news-letter',
  templateUrl: './news-letter.component.html',
  styleUrls: ['./news-letter.component.css']
})
export class NewsLetterComponent implements OnInit {

  reasonSingupTypes = ['Advert', 'Word Of Mouth', 'Other'];
  userSettings: NewsLetterForm = {
    email: 'wes@awd.com',
    reasonSingup: this.reasonSingupTypes[0],
    heardAbout: 'akakaka'
  };
  errorMessage = '';

  constructor(private dataService: DataService) {

  }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    if (form.valid) {
      this.dataService.postNewsLetterForm(form.value)
      .subscribe({
        next: () => this.onSaveComplete(),
        error: err => this.errorMessage = err
      });
    }
  }

  private onSaveComplete() {
    console.log('on save complete');
    this.errorMessage = '';
  }
}
