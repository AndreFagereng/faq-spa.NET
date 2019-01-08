import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { CustomerQuestions } from '../Models/CustomerQuestions';
import { HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'customer-faq.component',
  templateUrl: './customer-faq.component.html',
  styleUrls: ['./customer-faq.component.css']
})


export class CustomerFaqComponent {
  schema: FormGroup;
  viewSchema: boolean;
  showCQuestions: boolean;
  showSchemaResponse: boolean;
  showTopRatedQuestion: boolean;
  loading: boolean;
  schemaButtonString: string;
  topQButtonString: string;

  topRatedQuestion: Array<CustomerQuestions>;
  customerQuestions: Array<CustomerQuestions>;

  //Constructor
  //Uses HttpClient for Webapi towards the backend C#.
  //Formbuilder used for formgroup Object in send question schema
  constructor(private _http: HttpClient, private fb: FormBuilder) {
    this.schema = fb.group({
      email: [""],
      question: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-.,? 0-9]{5,250}")])]
    });   
  }

  //Initialize metoden
  //Initialiserer all the nessecary variables used in the frontend.
  ngOnInit() {
    this.schemaButtonString = "Send inn spørsmål";
    this.topQButtonString = "Top 5";
    this.viewSchema = false;
    this.showCQuestions = false;
    this.showSchemaResponse = false;
    this.showTopRatedQuestion = false;
    this.loading = true;
    setTimeout(() => {
      
    },
      5000);
    this.getCQuestions();
  }

  //SaveCustomerQuestion method
  //Uses the SaveCQuestion method for sending a
  //post request with the fields from schema.
  saveCustomerQuestion() {
    this.saveCQuestion();

    //Reset the value of the schema
    this.schema.setValue({
      email: "",
      question: ""
    });
    //Hides the schema after questions been sent
    this.showSchema();
  }


  //ShowTopQuestion method
  //Uses the GetTopCQuestion get method to retrieve all the
  //top 5 questions from database based on "Upvotes".
  //Changes the string for the button in UI.
  showTopQuestions() {
    this.getTopCQuestions();
    this.showTopRatedQuestion = !this.showTopRatedQuestion;
    if (this.showTopRatedQuestion) {
      this.topQButtonString = "Tilbake"
    } else {
      this.topQButtonString = "Top 5"
    }
  }

  //ShowSchema method
  //Shows and hides the schema in UI
  //Changes the button string depending on viewSchema bool variable
  showSchema() {
    this.viewSchema = !this.viewSchema;
    if (this.viewSchema) {
      this.schemaButtonString = "Tilbake";
    } else {
      this.schemaButtonString = "Send inn spørsmål";
    }
  }

  //IncrementThumbs method
  //Uses the incrementInDatabase method for
  //PUT request towards the backend/database.
  //Increasing Upvotes or Downvotes
  //Then it updates the votes live in UI, so it doesnt
  //need to send a GET request to retrieve it again.
  incrementThumbs(increment: string, id: number) {

    if (increment === 'True') {
      this.incrementInDatabase(increment, id);
      this.updateLive(true, id);
    } else {
      this.incrementInDatabase(increment, id);
      this.updateLive(false, id);
    }

  }

  //IncrementInDatabase method
  //Increments the Upvotes or Downvotes in the database
  //via a PUT request.
  incrementInDatabase(increment: string, id: number) {
    var headers = new HttpHeaders({ "Content-Type": "application/json" });
    var postBody: string = JSON.stringify(increment);
    
    this._http.put('api/CustomerFAQ/' + id, postBody, {headers: headers}).subscribe(result => {
      //this.getCQuestions();
    },
      error => alert(error),
      () => console.log("Successfull put-api/CustomerFAQ/id")
    );
  }

  //GetCQuestions method
  //Sends a GET request to database to retrieve all
  //the customer questions with answers.
  getCQuestions() {
    this._http.get<CustomerQuestions[]>('api/CustomerFAQ/').subscribe(result => {
      this.customerQuestions = [];
      this.customerQuestions = result;
      this.loading = false;
    }, error => console.error(error));
  }

  //GetTopCQuestions method
  //Sends a GET request to database to retrieve all
  //the customer questions that is ranked top 5 on Upvotes.
  getTopCQuestions() {
    this._http.get<CustomerQuestions[]>('api/CustomerFAQ/GetTopRated').subscribe(result => {
      this.topRatedQuestion = [];
      this.topRatedQuestion = result;
      console.log("Get top succeed")
    }, error => console.error(error));
  }

  //SaveCQuestion method
  //Sends a POST request to the backend/database with the fields of the
  //schema. If the email has not been put in, autmatically set it as "Anonym".
  //After POST request, the getCQuestions method is called to update the question
  //in UI.
  saveCQuestion() {

    var newQ = new CustomerQuestions();

    newQ.Downvotes = 0;
    newQ.Upvotes = 0;
    newQ.Question = this.schema.value.question;
    if (this.schema.value.email == "") {
      newQ.Email = "Anonym";
    } else {
      newQ.Email = this.schema.value.email;
    }

    var postBody: string = JSON.stringify(newQ);
    var headers = new HttpHeaders({ "Content-Type": "application/json" });
    
    this._http.post('api/CustomerFAQ', postBody, { headers: headers })
      .subscribe(
      returns => {
        this.getCQuestions();
        this.showSchemaResponse = true;
        },
        error => alert(error),
        () => console.log("done post-api/CustomerFAQ")
      );

  };

  //UpdateLive method
  //Updates the Upvotes and Downvotes live for the user, so
  //its not needed to send a GET request to apply the correct
  //values for Upvotes/Downvotes.
  updateLive(increment: boolean, id: number) {
    this.customerQuestions.forEach((obj) => {
      if (increment) {
        if (obj.CQID == id) {
          obj.Upvotes = obj.Upvotes + 1
        }
      } else {
        if (obj.CQID == id) {
          obj.Downvotes = obj.Downvotes + 1
        }
      }
    });
    this.topRatedQuestion.forEach((obj) => {
      if (increment) {
        if (obj.CQID == id) {
          obj.Upvotes = obj.Upvotes + 1
        }
      } else {
        if (obj.CQID == id) {
          obj.Downvotes = obj.Downvotes + 1
        }
      }
    });
  }
}
