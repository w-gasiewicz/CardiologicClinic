from keras.models import load_model
import numpy as np

def LoadModel():
    model = load_model('medical_module.h5')
    return model

def PredictPatientData(model):    
    # load input
    data = np.loadtxt('./predict.txt', delimiter=";", dtype=np.int)
    predict = model.predict_classes(np.array([data,]))
    #print(predict)
    return predict

def main():
    model = LoadModel()
    result = PredictPatientData(model)
    x = 5 + 9
    print (result[0])
    k=input("press close to exit") 

if __name__ == "__main__":
    main()