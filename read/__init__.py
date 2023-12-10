import logging

import azure.functions as func

import json


# This function is used to read from the database!
def main(req: func.HttpRequest, query: func.SqlRowList) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')

    rows = list(map(lambda r: json.loads(r.to_json()), query))

    return func.HttpResponse(
        json.dumps(rows),
        status_code=200,
        mimetype="application/json"
    ) 
