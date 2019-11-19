#script to make prediction
from keras.models import load_model
import numpy as np

def LoadModel():
    model = load_model('medical_module.h5')
    return model

def PredictPatientData(model):    
    # load input
    data = np.loadtxt('./predict.txt', delimiter=";", dtype=np.int)
    predict = model.predict_classes(np.array([data,]))  
    pro=model.predict_proba(np.array([data,]))
    toreturn = str(predict[0])+";"+str(pro[0,predict[0]]*100)
    return toreturn

def main():
    model = LoadModel()
    result = PredictPatientData(model)
    
    filew = open("output.txt","w") 
    filew.write(str(result)) 
    filew.close()
    
if __name__ == "__main__":
    main()