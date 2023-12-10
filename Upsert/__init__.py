import logging
import azure.functions as func

# This function is used to update or insert an item!
def main(req: func.HttpRequest, upsert: func.Out[func.SqlRow]) -> func.HttpResponse:
    logging.info('Python HTTP trigger Upsert and SQL output binding function processed a request.')

    try:
        req_body = req.get_json()
        row = func.SqlRow.from_dict(req_body)
        upsert.set(row)
    except ValueError:
        pass

    if req_body:
        #upsert.set(rows)
        return func.HttpResponse(
            #upsert.to_json(),
             "Success!",
            status_code=201,
            #mimetype="application/json"
    )
    else:
        return func.HttpResponse(
            "Error accessing request body.",
            status_code=400
        )
