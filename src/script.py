# script à reporter dans Machine Learning Studio
dataframe1 = dataframe1.sort_values(by='Dress_ID')
dataframe2 = dataframe2.sort_values(by='Dress_ID')
dataframe1['ventes'] = dataframe2['ventes']
for col in ['SleeveLength', 'waiseline', 'Material', 'FabricType', 'Decoration', 'Pattern Type']:
    dataframe1[col] = dataframe1[col].replace({'null': 'nc', 'NULL': None})
return dataframe1
