import { Component, OnInit} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Questions, QEnumType} from "../Models/Questions";
import "rxjs/add/operator/map";


@Component({
  selector: 'app-faq-component',
  templateUrl: './FAQ.component.html',
  styleUrls: ['./FAQ.component.css']
})
export class FaqComponent {

  public allQuestions: Questions[];
  public subjectQuestion: Questions[];
  public QEnumType: QEnumType;
  public EnumType = QEnumType.Payments;

  //Constructor
  //Uses HttpClient for Webapi towards the backend C#.
  constructor(private _http: HttpClient) {

  }

  //Initialize method
  //Runs the getFAQQuestions to get all the seeded
  //questions from the database
  ngOnInit() {
    this.getFAQQuestions();
  }

  //ShowBySubject method
  //This is looping all questions and
  //get the correct subject.(Bruker, Kunde, Betaling etc.)
  showBySubject(subject: string) {
    this.elementActive();
    this.subjectQuestion = [];
    for (let i of this.allQuestions) {
      if (i.Qtype === subject) {
        this.subjectQuestion.push(i);
      }
    }
  }


  //GetFAQQuestions method
  //Sends a GET request towards the webapi to
  //retrieve all the questions and answers in database.
  getFAQQuestions() {
    this._http.get<Questions[]>('api/FAQ/').subscribe(result => {
      this.allQuestions = [];
      this.allQuestions = result;
      
      this.showBySubject('Account');
      //console.log(result);
      
    }, error => console.error(error));
  }

  //ElementActive method
  //Sets the clicked DIV to active, which get the appropriate CSS
  //from the css file. Highlights the DIV that is pressed.
  elementActive() {

    var allFaqAccordion = document.getElementById("faqAccordion");
    var divs = allFaqAccordion.getElementsByClassName("navigateActive");
    
    for (var i = 0; i < divs.length; i++) {
      divs[i].addEventListener("click", function () {
        var current = document.getElementsByClassName("active");
        current[0].className = current[0].className.replace(" active", "");
        this.className += " active";
      });
    }
  }
}
