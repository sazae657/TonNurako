.SUFFIXES: .iso .cs .swift 
include Config.mp3
-include Site.mp3

PLATFORM := SunOS
BUILD := Debug
LINKER := $(CC)
BINDIR := ../bin/$(BUILD)/


CFLAGS := $(CFLAGS) -Iimport.app $(MOTF_HEADER_ARGS) $(X11_HEADER_ARGS)
LINK_LIBS := -Limport.app/lib $(MOTF_LIBRARY_ARGS) $(MOTIF_LIBS) $(X11_LIBRARY_ARGS) $(X11_LIBS)
LINK_FLAGS := -g -shared
OPT := -g -D_DEBUG
GEN_CFLAGS := -Wno-format

# チェック
CHECK_ARGS=Check Args
COMMON_C=iso.app/Contents/Resources/Shop.c
COMMON_I=-Iiso.app/Contents/Resources

MOTIF_CHECK_C=iso.app/Contents/Resources/MotifCheck.c $(COMMON_C)
MOTIF_CHECK_E=iso.app/Contents/MacOS/iso

LIB_CHECK_C=scripts.app/Contents/Resources/LibCheck.c $(COMMON_C)
LIB_CHECK_E=scripts.app/Contents/MacOS/scripts

IMP_CHECK_C=import.app/Contents/Resources/ImpCheck.c $(COMMON_C)
IMP_CHECK_E=import.app/Contents/MacOS/import

RULES_OK_DIR=tmpfile.app/Contents/_CodeSignature
RULES_OK_FILE=tmpfile.app/Contents/_CodeSignature/Zakefile

# 自動生成用
GEN_EXE := tmpfile.app/Contents/MacOS/gen
GEN_C := tmpfile.app/Contents/Resources/gen.c
GEN_SRC_DIR := ../TonNurako/Native/GEN
TEMPLATE_DIR := iso.app
SCRIPT_DIR := scripts.app

XM_CONSTANT_CS=$(GEN_SRC_DIR)/Xm.Constant.cs
XM_CONSTANT_CS_TPL=$(TEMPLATE_DIR)/Xm.Constant.iso

XM_RESOURCEID_CS=$(GEN_SRC_DIR)/Xm.ResourceId.cs
XM_RESOURCEID_CS_TPL=$(TEMPLATE_DIR)/Xm.ResourceId.iso

XM_STRINGCONSTANT_CS=$(GEN_SRC_DIR)/Xm.StringConstant.cs
XM_STRINGCONSTANT_CS_TPL=$(TEMPLATE_DIR)/Xm.StringConstant.iso

X_CONSTANT_CS=$(GEN_SRC_DIR)/X.Constant.cs
X_CONSTANT_CS_TPL=$(TEMPLATE_DIR)/X.Constant.iso
X_CONSTANT_CS_MAP=$(GEN_SRC_DIR)/X.Constant.map

X_STRINGCONSTANT_CS=$(GEN_SRC_DIR)/X.StringConstant.cs
X_STRINGCONSTANT_CS_TPL=$(TEMPLATE_DIR)/X.StringConstant.swift
X_STRINGCONSTANT_CS_MAP=$(GEN_SRC_DIR)/X.StringConstant.map

X_PROTO_CS=$(GEN_SRC_DIR)/X.Proto.cs
X_PROTO_CS_TPL=$(TEMPLATE_DIR)/X.Proto.swift
X_PROTO_CS_MAP=$(GEN_SRC_DIR)/X.Proto.map

X_ATOM_CS=$(GEN_SRC_DIR)/X.Atom.cs
X_ATOM_CS_TPL=$(TEMPLATE_DIR)/X.Atom.swift
X_ATOM_CS_MAP=$(GEN_SRC_DIR)/X.Atom.map

X_KEYSYM_CS=$(GEN_SRC_DIR)/X.KeySym.cs
X_KEYSYM_CS_TPL=$(TEMPLATE_DIR)/X.KeySym.swift
X_KEYSYM_CS_MAP=$(GEN_SRC_DIR)/X.KeySym.map
X_KEYSYM_CS_PP=	-DXK_3270

ifeq ($(BUILD),Release)
	OPT = -O2 -DNDEBUG
endif

ifeq ($(PLATFORM), Darwin)
	LINK_FLAGS += -dynamiclib
endif

OBJ=DlSym.o	\
 	ClassDef.o \
 	XmImport.o \
	XtImport.o  \
	X11Import.o \
	X11ImportMacro.o \
	X11ImportLocale.o \
	XkbImport.o \
    TonNurako.o \
	XmCreateFuncs.o \
	X11ExtShapeImp.o \
	X11ExtRenderImp.o \
	X11ImpGC.o \

TARGET = $(BINDIR)libTonNurako.extremesports

.c.o:
	$(CC) $(OPT) $(CFLAGS) $(WARN_OPT) -c  $< -o $@

all: ExtremeSports GenSrc

ExtremeSports: check $(TARGET)

$(TARGET): $(OBJ)
	$(LINKER) $(LINK_FLAGS) -o $(TARGET) $(OBJ) $(LINK_LIBS)

$(OBJ): $(BINDIR)

$(BINDIR):
	mkdir -p $(BINDIR)

# ﾁｪｯｸ
check: $(RULES_OK_FILE)

speaker: $(LIB_CHECK_E)  $(MOTIF_CHECK_E) $(IMP_CHECK_E)
	@ $(LIB_CHECK_E) $(CHECK_ARGS)
	@ $(MOTIF_CHECK_E) $(CHECK_ARGS)
	@ $(IMP_CHECK_E) $(CHECK_ARGS)

$(RULES_OK_FILE): $(LIB_CHECK_E)  $(MOTIF_CHECK_E) $(IMP_CHECK_E)
	@ $(LIB_CHECK_E) $(CHECK_ARGS)
	@ $(MOTIF_CHECK_E) $(CHECK_ARGS)
	@ $(IMP_CHECK_E) $(CHECK_ARGS)


$(LIB_CHECK_E): $(LIB_CHECK_C) $(MOTIF_CHECK_E) $(IMP_CHECK_E)
	$(CC) $(CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(LIB_CHECK_E) $(LIB_CHECK_C) $(LINK_LIBS)

$(MOTIF_CHECK_E): $(MOTIF_CHECK_C)
	$(CC) $(CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(MOTIF_CHECK_E) $(MOTIF_CHECK_C) $(LINK_LIBS)

$(IMP_CHECK_E): $(IMP_CHECK_C)
	$(CC) $(CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(IMP_CHECK_E) $(IMP_CHECK_C) $(LINK_LIBS)


# ほほほ

GenSrc: $(XM_CONSTANT_CS) $(XM_RESOURCEID_CS) $(XM_STRINGCONSTANT_CS) $(X_CONSTANT_CS) $(X_PROTO_CS) $(X_ATOM_CS) $(X_KEYSYM_CS) $(X_STRINGCONSTANT_CS)

$(TEMP_BIN):
	mkdir -p $(TEMP_BIN)

#TODO: ↓これなんとかならんものか
$(XM_CONSTANT_CS): $(XM_CONSTANT_CS_TPL)
	$(PYTHON) $(SCRIPT_DIR)/const_ex.py $(XM_CONSTANT_CS_TPL) >$(GEN_C)
	$(CC) $(CFLAGS) $(GEN_CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(GEN_EXE) $(GEN_C) $(COMMON_C) $(LINK_LIBS)
	$(GEN_EXE) >$(XM_CONSTANT_CS)

$(XM_RESOURCEID_CS): $(XM_RESOURCEID_CS_TPL)
	$(PYTHON) $(SCRIPT_DIR)/const_ex.py $(XM_RESOURCEID_CS_TPL) >$(GEN_C)
	$(CC) $(CFLAGS) $(GEN_CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(GEN_EXE) $(GEN_C) $(COMMON_C)  $(LINK_LIBS)
	$(GEN_EXE) >$(XM_RESOURCEID_CS)

$(XM_STRINGCONSTANT_CS): $(XM_STRINGCONSTANT_CS_TPL)
	$(PYTHON) $(SCRIPT_DIR)/const_ex.py $(XM_STRINGCONSTANT_CS_TPL) >$(GEN_C)
	$(CC) $(CFLAGS) $(GEN_CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(GEN_EXE) $(GEN_C) $(COMMON_C) $(LINK_LIBS)
	$(GEN_EXE) >$(XM_STRINGCONSTANT_CS)

$(X_CONSTANT_CS): $(X_CONSTANT_CS_TPL)
	$(PYTHON) $(SCRIPT_DIR)/const_ex.py $(X_CONSTANT_CS_TPL) >$(GEN_C)
	$(CC) $(CFLAGS) $(GEN_CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(GEN_EXE) $(GEN_C) $(COMMON_C) $(LINK_LIBS)
	$(GEN_EXE) >$(X_CONSTANT_CS)
	$(PYTHON) $(SCRIPT_DIR)/map.py $(X_CONSTANT_CS_TPL) >$(X_CONSTANT_CS_MAP)

$(X_PROTO_CS): $(X_PROTO_CS_TPL)
	$(PYTHON) $(SCRIPT_DIR)/const_ex.py $(X_PROTO_CS_TPL) >$(GEN_C)
	$(CC) $(CFLAGS) $(GEN_CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(GEN_EXE) $(GEN_C) $(COMMON_C) $(LINK_LIBS)
	$(GEN_EXE) >$(X_PROTO_CS)
	$(PYTHON) $(SCRIPT_DIR)/map.py $(X_PROTO_CS_TPL) >$(X_PROTO_CS_MAP)

$(X_ATOM_CS): $(X_ATOM_CS_TPL)
	$(PYTHON) $(SCRIPT_DIR)/const_ex.py $(X_ATOM_CS_TPL) >$(GEN_C)
	$(CC) $(CFLAGS) $(GEN_CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(GEN_EXE) $(GEN_C) $(COMMON_C) $(LINK_LIBS)
	$(GEN_EXE) >$(X_ATOM_CS)
	$(PYTHON) $(SCRIPT_DIR)/map.py $(X_ATOM_CS_TPL) >$(X_ATOM_CS_MAP)

$(X_KEYSYM_CS): $(X_KEYSYM_CS_TPL)
	$(PYTHON) $(SCRIPT_DIR)/const_ex.py $(X_KEYSYM_CS_TPL) >$(GEN_C)
	$(CC) $(CFLAGS) $(GEN_CFLAGS) $(X_KEYSYM_CS_PP) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(GEN_EXE) $(GEN_C) $(COMMON_C) $(LINK_LIBS)
	$(GEN_EXE) >$(X_KEYSYM_CS)
	$(PYTHON) $(SCRIPT_DIR)/map.py $(X_KEYSYM_CS_TPL) >$(X_KEYSYM_CS_MAP)


$(X_STRINGCONSTANT_CS): $(X_STRINGCONSTANT_CS_TPL)
	$(PYTHON) $(SCRIPT_DIR)/const_ex.py $(X_STRINGCONSTANT_CS_TPL) >$(GEN_C)
	$(CC) $(CFLAGS) $(GEN_CFLAGS) $(X_STRINGCONSTANT_CS_PP) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(GEN_EXE) $(GEN_C) $(COMMON_C) $(LINK_LIBS)
	$(GEN_EXE) >$(X_STRINGCONSTANT_CS)
	$(PYTHON) $(SCRIPT_DIR)/map.py $(X_STRINGCONSTANT_CS_TPL) >$(X_STRINGCONSTANT_CS_MAP)


clean.lib:
	- rm -rf *.o
	- rm -rf $(TARGET)
	- rm -rf dep
	- rm -rf core

clean: clean.lib
	- rm $(MOTIF_CHECK_E) $(LIB_CHECK_E) $(IMP_CHECK_E) $(RULES_OK_DIR)/*file
	- rm $(XM_CONSTANT_CS) $(XM_RESOURCEID_CS) $(XM_STRINGCONSTANT_CS) $(X_CONSTANT_CS)

install: clean

audio:
	./config.sh
