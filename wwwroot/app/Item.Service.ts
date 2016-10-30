
import { Injectable      } from "@angular/core";
import { Http, Response  } from "@angular/http";
import { Item            } from "./Item";
import { Observable      } from "rxjs/Observable";     // TypeScript fix:  http://stackoverflow.com/a/37331027
import 'rxjs/add/operator/map';

@Injectable()
export class ItemService {

    private baseUrl = "api/items/";      // web API URL

    ///
    /// Constructor
    /// Must receive Http object
    constructor(private http: Http) {
    }

    ///
    /// Function will class [GET] on /api/items/GetLAtest/{num} Web API method
    /// to retrieve latest items
    getLatest(num?: number) {
        var url = this.baseUrl + "GetLatest/";
        if (num != null) {
            url += num;
        }

        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }


    ///
    /// Function call [GET] on /api/items/GetRandom/{num} Web API method to retrieve a random items
    getMostViewed(num?: number) {
        var url = this.baseUrl + "GetMostViewed/";
        if (num != null) {
            url += num;
        }

        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    getRandom(num?: number) {
        var url = this.baseUrl + "GetRandom/";
        if (num != null) {
            url += num;
        }

        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    ///
    /// Function call [GET] on /api/items/{id} Web API method to retrieve 
    /// the item with given id
    get(id: number) {
        if (id == null) {
            throw new Error("id is required");
        }

        var url = this.baseUrl + id;

        return this.http.get(url)
            .map(response => <Item> response.json())
            .catch(this.handleError);
    }

    ///
    /// Function will handle an errors in response from server
    private handleError(error: Response) {
        // Print error to console
        console.error(error);

        return Observable.throw(error.json().error || "Server error");
    } 
}